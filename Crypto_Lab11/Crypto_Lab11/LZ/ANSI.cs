using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab11.LZ
{
    class Ansi
    {
        private readonly Dictionary<string, int> table = new Dictionary<string, int>();
        public Dictionary<string, int> Table => this.table;

        public Ansi()
        {
            for (int i = 0; i < 256; i++)
            {
                this.table.Add(Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }
        }

        public void WriteLine()
        {
            this.table.WriteLine();
        }

        public void WriteToFile()
        {
            File.WriteAllText("ANSI.txt", this.table.ToStringLines(), Encoding.Default);
        }
    }
}
