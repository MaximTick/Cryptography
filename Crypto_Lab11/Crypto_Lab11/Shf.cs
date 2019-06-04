using System;
using System.Text;

namespace Crypto_Lab11
{
    public class Shf
    {
        public class BitStream
        {
            public byte[] BytePointer;
            public uint BitPosition;
            public uint Index;
        }

        public struct Symbol
        {
            public uint Sym;
            public uint Count;
            public uint Code;
            public uint Bits;
        }

        private static void InitBitStream(ref BitStream stream, byte[] buffer)
        {
            stream.BytePointer = buffer;
            stream.BitPosition = 0;
        }

        private static void WriteBits(ref BitStream stream, uint x, uint bits)
        {
            var buffer = stream.BytePointer;
            var bit = stream.BitPosition;
            var mask = (uint)(1 << (int)(bits - 1));

            for (uint count = 0; count < bits; ++count)
            {
                buffer[stream.Index] = (byte)((buffer[stream.Index] & (0xff ^ (1 << (int)(7 - bit)))) + ((Convert.ToBoolean(x & mask) ? 1 : 0) << (int)(7 - bit)));
                x <<= 1;
                bit = (bit + 1) & 7;

                if (!Convert.ToBoolean(bit))
                {
                    ++stream.Index;
                }
            }

            stream.BytePointer = buffer;
            stream.BitPosition = bit;
        }

        private static void Histogram(byte[] input, Symbol[] sym, uint size)
        {
            Symbol temp;
            int i, swaps;
            var index = 0;

            for (i = 0; i < 256; ++i)
            {
                sym[i].Sym = (uint)i;
                sym[i].Count = 0;
                sym[i].Code = 0;
                sym[i].Bits = 0;
            }

            for (i = (int)size; Convert.ToBoolean(i); --i, ++index)
            {
                sym[input[index]].Count++;
            }

            do
            {
                swaps = 0;

                for (i = 0; i < 255; ++i)
                {
                    if (sym[i].Count < sym[i + 1].Count)
                    {
                        temp = sym[i];
                        sym[i] = sym[i + 1];
                        sym[i + 1] = temp;
                        swaps = 1;
                    }
                }
            } while (Convert.ToBoolean(swaps));
        }

        private static void MakeTree(Symbol[] sym, ref BitStream stream, uint code, uint bits, uint first, uint last)
        {
            uint i, size, sizeA, sizeB, lastA, firstB;

            if (first == last)
            {
                WriteBits(ref stream, 1, 1);
                WriteBits(ref stream, sym[first].Sym, 8);
                sym[first].Code = code;
                sym[first].Bits = bits;
                return;
            }
            else
            {
                WriteBits(ref stream, 0, 1);
            }

            size = 0;

            for (i = first; i <= last; ++i)
            {
                size += sym[i].Count;
            }

            sizeA = 0;

            for (i = first; sizeA < ((size + 1) >> 1) && i < last; ++i)
            {
                sizeA += sym[i].Count;
            }

            if (sizeA > 0)
            {
                WriteBits(ref stream, 1, 1);

                lastA = i - 1;

                MakeTree(sym, ref stream, (code << 1) + 0, bits + 1, first, lastA);
            }
            else
            {
                WriteBits(ref stream, 0, 1);
            }

            sizeB = size - sizeA;

            if (sizeB > 0)
            {
                WriteBits(ref stream, 1, 1);

                firstB = i;

                MakeTree(sym, ref stream, (code << 1) + 1, bits + 1, firstB, last);
            }
            else
            {
                WriteBits(ref stream, 0, 1);
            }
        }

        public static int Compress(byte[] input, byte[] output, uint inputSize)
        {
            var sym = new Symbol[256];
            Symbol temp;
            var stream = new BitStream();
            uint i, totalBytes, swaps, symbol, lastSymbol;

            if (inputSize < 1)
                return 0;

            InitBitStream(ref stream, output);
            Histogram(input, sym, inputSize);

            for (lastSymbol = 255; sym[lastSymbol].Count == 0; --lastSymbol) ;

            if (lastSymbol == 0)
                ++lastSymbol;

            MakeTree(sym, ref stream, 0, 0, 0, lastSymbol);

            do
            {
                swaps = 0;

                for (i = 0; i < 255; ++i)
                {
                    if (sym[i].Sym > sym[i + 1].Sym)
                    {
                        temp = sym[i];
                        sym[i] = sym[i + 1];
                        sym[i + 1] = temp;
                        swaps = 1;
                    }
                }
            } while (Convert.ToBoolean(swaps));

            for (i = 0; i < inputSize; ++i)
            {
                symbol = input[i];
                WriteBits(ref stream, sym[symbol].Code, sym[symbol].Bits);
            }

            totalBytes = stream.Index;

            if (stream.BitPosition > 0)
            {
                ++totalBytes;
            }

            return (int)totalBytes;
        }
        private const int MaxTreeNodes = 511;


        public class TreeNode
        {
            public TreeNode ChildA;
            public TreeNode ChildB;
            public int Symbol;
        }

        private static uint ReadBit(ref BitStream stream)
        {
            var buffer = stream.BytePointer;
            var bit = stream.BitPosition;
            var x = (uint)(Convert.ToBoolean(buffer[stream.Index] & (1 << (int)(7 - bit))) ? 1 : 0);
            bit = (bit + 1) & 7;

            if (!Convert.ToBoolean(bit))
            {
                ++stream.Index;
            }

            stream.BitPosition = bit;

            return x;
        }

        private static uint Read8Bits(ref BitStream stream)
        {
            var buffer = stream.BytePointer;
            var bit = stream.BitPosition;
            var x = (uint)((buffer[stream.Index] << (int)bit) | (buffer[stream.Index + 1] >> (int)(8 - bit)));
            ++stream.Index;

            return x;
        }

        private static TreeNode RecoverTree(TreeNode[] nodes, ref BitStream stream, ref uint nodeNumber)
        {
            TreeNode thisNode;

            thisNode = nodes[nodeNumber];
            nodeNumber = nodeNumber + 1;

            thisNode.Symbol = -1;
            thisNode.ChildA = null;
            thisNode.ChildB = null;

            if (Convert.ToBoolean(ReadBit(ref stream)))
            {
                thisNode.Symbol = (int)Read8Bits(ref stream);
                return thisNode;
            }

            if (Convert.ToBoolean(ReadBit(ref stream)))
            {
                thisNode.ChildA = RecoverTree(nodes, ref stream, ref nodeNumber);
            }

            if (Convert.ToBoolean(ReadBit(ref stream)))
            {
                thisNode.ChildB = RecoverTree(nodes, ref stream, ref nodeNumber);
            }

            return thisNode;
        }

        public static void Decompress(byte[] input, byte[] output, uint inputSize, uint outputSize)
        {
            var nodes = new TreeNode[MaxTreeNodes];

            for (var counter = 0; counter < nodes.Length; counter++)
            {
                nodes[counter] = new TreeNode();
            }

            var stream = new BitStream();
            uint i;

            if (inputSize < 1) return;

            InitBitStream(ref stream, input);

            uint nodeCount = 0;
            var root = RecoverTree(nodes, ref stream, ref nodeCount);
            var buffer = output;

            for (i = 0; i < outputSize; ++i)
            {
                var node = root;

                while (node.Symbol < 0)
                {
                    node = Convert.ToBoolean(ReadBit(ref stream)) ? node.ChildB : node.ChildA;
                }

                buffer[i] = (byte)node.Symbol;
            }
        }
        public static void Do()
        {
            var str = "This is an example for Shannon–Fano coding";
            var originalData = Encoding.Default.GetBytes(str);
            var originalDataSize = (uint)str.Length;
            var compressedData = new byte[originalDataSize * (101 / 100) + 384];

            var compressedDataSize = Compress(originalData, compressedData, originalDataSize);
            Console.WriteLine("size = " + compressedDataSize);

            var decompressedData = new byte[originalDataSize];

            Decompress(compressedData, decompressedData, (uint)compressedDataSize, originalDataSize);

            Console.WriteLine("Decompressed = " + Encoding.Default.GetString(decompressedData));
        }
    }
}
