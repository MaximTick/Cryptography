using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab11.LZ
{
    class BitReader : IDisposable
    {
        BufferedStream s = null;
        MemoryStream ms = null;

        bool disposed = false;
        byte? b = null;
        int pos = 0;

        public BitOrder bitOrder = BitOrder.LeftToRight;
        public bool EndOfStream;

        public BitReader(BufferedStream _s)
        {
            this.s = _s;
        }

        public BitReader(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;

            this.s = new BufferedStream(ms);
        }


        public bool? ReadBit()
        {
            bool? result = null;

            try
            {
                if (this.b == null || (this.pos % 8 == 0))
                {
                    int i = this.s.ReadByte();

                    if (i == -1)
                    {
                        throw new EndOfStreamException();
                    }
                    else
                    {
                        this.b = Convert.ToByte(i);
                    }

                    this.pos = 0;
                }

                if (this.bitOrder == BitOrder.LeftToRight)
                {
                    result = Convert.ToBoolean(this.b & (1 << (7 - this.pos)));
                }
                else if (this.bitOrder == BitOrder.RightToLeft)
                {
                    result = Convert.ToBoolean((this.b >> this.pos) % 2);
                }

                this.pos++;

                return result;
            }
            catch (EndOfStreamException)
            {
                this.EndOfStream = true;
                return null;
            }
        }

        public bool?[] ReadBits(int n)
        {
            bool?[] bits = new bool?[n];

            for (int i = 0; i < n; i++)
            {
                bool? bit = this.ReadBit();
                bits[i] = bit;
            }

            return bits;
        }

        public bool[] ReadAll()
        {
            List<bool> bits = new List<bool>();
            bool? bit = null;
            while ((bit = this.ReadBit()) != null)
            {
                bits.Add(bit.Value);
            }

            return bits.ToArray();
        }

        public long Position
        {
            get
            {
                return ((this.s.Position - 1) * 8) + (this.pos - 1);
            }
        }

        public long Length
        {
            get
            {
                return this.s.Length * 8;
            }
        }


        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // Dispose managed resources
                if (disposing)
                {
                    if (this.s != null)
                    {
                        this.s.Close();
                    }

                    if (this.ms != null)
                    {
                        this.ms.Close();
                    }
                }

                // Dispose unmanaged resources
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        public enum BitOrder
        {
            LeftToRight = 0,
            RightToLeft = 1
        }
    }
}

