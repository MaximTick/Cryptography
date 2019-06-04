using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab06
{
    public static class TripleDES
    {
        private static Random random = new Random();

        private static Tuple<int[], int[], int[]> SplitKey(string keyHex)
        {
            var key1 = GetBitsFromHexStr(keyHex.Substring(0, 16));
            var key2 = GetBitsFromHexStr(keyHex.Substring(16, 16));
            var key3 = GetBitsFromHexStr(keyHex.Substring(32, 16));

            return new Tuple<int[], int[], int[]>(key1, key2, key3);
        }

        private static int[] GetBitsFromHexStr(string hexStr)
        {
            int[] bits = new int[64];
            string inputBinary = HexConverter.HexToBinary(hexStr);
            bits = inputBinary.Select(i => int.Parse(i + "")).ToArray();

            return bits;
        }

        private static List<int[]> SplitToBitBlocks(string strHex)
        {
            var blocks = new List<int[]>();
            var strBinary = HexConverter.HexToBinary(strHex);
            var binaryBlocks = strBinary.SplitInParts(64).ToArray();

            foreach (var block in binaryBlocks)
            {
                var bits = block.Select(el => int.Parse(el + "")).ToArray();
                blocks.Add(bits);
            }

            return blocks;
        }

        public static List<int[]> SplitToBitBlocksUsingTBC(string strHex)
        {
            var blocks = new List<int[]>();
            var strBinary = HexConverter.HexToBinary(strHex);
            var binaryBlocks = strBinary.SplitInParts(64).ToArray();
            int paddingValue = strBinary.Last() == '0' ? 1 : 0;

            for (int i = 0; i < binaryBlocks.Length; i++)
            {
                var currentBlock = binaryBlocks[i];
                if (currentBlock.Length < 64)
                {
                    currentBlock = TBC(currentBlock);
                }
                var bits = currentBlock.Select(el => int.Parse(el + "")).ToArray();
                blocks.Add(bits);
            }

            // Add last block
            blocks.Add(Enumerable.Repeat(paddingValue, 64).ToArray());

            return blocks;
        }

        private static string TBC(string strBinary)
        {
            string paddingValue = strBinary.Last() == '0' ? "1" : "0";
            while (strBinary.Length < 64)
            {
                strBinary += paddingValue;
            }

            return strBinary;
        }

        public static string Encrypt(string keyHex, string strHexToEncrypt)
        {
            var subKeys = SplitKey(keyHex);
            var bitBlocks = SplitToBitBlocksUsingTBC(strHexToEncrypt);
            var encryptedBits = new List<int[]>();

            for (int i = 0; i < bitBlocks.Count; i++)
            {
                int[] cipher1 = DES.Encrypt(subKeys.Item1, bitBlocks[i]);
                int[] cipher2 = DES.Decrypt(subKeys.Item2, cipher1);
                int[] cipher3 = DES.Encrypt(subKeys.Item3, cipher2);
                encryptedBits.Add(cipher3);
            }

            return HexConverter.BitsToHex(encryptedBits);
        }

        public static string Decrypt(string keyHex, string cipher)
        {
            var subKeys = SplitKey(keyHex);
            var bitBlocks = SplitToBitBlocks(cipher);
            var decryptedBits = new List<int[]>();

            for (int i = 0; i < bitBlocks.Count; i++)
            {
                DES.Encrypt(subKeys.Item3, bitBlocks[i]);
                int[] decrypted3 = DES.Decrypt(subKeys.Item3, bitBlocks[i]);
                int[] decrypted2 = DES.Encrypt(subKeys.Item2, decrypted3);
                int[] decrypted1 = DES.Decrypt(subKeys.Item1, decrypted2);
                decryptedBits.Add(decrypted1);
            }
            // Remove padding 
            int paddingValue = decryptedBits.Last().First();
            int lastIndex = decryptedBits.Count - 1;
            decryptedBits.RemoveAt(lastIndex--); // Remove last additional block contains only padding value
            decryptedBits[lastIndex] = decryptedBits[lastIndex].TrimEnd(paddingValue);

            string decryptedHex = HexConverter.BitsToHex(decryptedBits);
            return HexConverter.HexStrToStr(decryptedHex);
        }

        public static string GetRandomKeyHex()
        {
            string keyHex = "";
            for (int i = 0; i < 48; i++)
            {
                keyHex += random.Next(16).ToString("X");
            }
            return keyHex;
        }
    }
}
