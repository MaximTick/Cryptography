using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab11.LZ
{
    public class LZWDecoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        int codeLen = 8;
        Ansi table;
        public LZWDecoder()
        {
            this.table = new Ansi();
            this.dict = this.table.Table;
        }

        public string DecodeFromCodes(byte[] bytes)
        {
            string output = bytes.GetBinaryString();

            return this.Decode(output);
        }

        public string Decode(string output)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            int prevValue = -1;

            while (i < output.Length)
            {
                if (i + this.codeLen + 8 <= output.Length)
                {
                    w = output.Substring(i, this.codeLen);
                }
                else if (i + this.codeLen <= output.Length)
                {
                    int encodedLen = i + this.codeLen;
                    int trimBitsLen = output.Length - encodedLen;

                    w = output.Substring(i, this.codeLen - (8 - trimBitsLen)) + output.Substring(output.Length - (8 - trimBitsLen), (8 - trimBitsLen));
                }
                else
                {
                    break;
                }

                i += this.codeLen;

                int value = Convert.ToInt32(w, 2);

                string key = this.dict.FindKey(value);
                string prevKey = this.dict.FindKey(prevValue);

                if (prevKey == null)
                {
                    prevKey = "";
                }

                if (key == null)
                {
                    //handles the situation cScSc
                    key = prevKey;

                    sb.Append(prevKey + key.Substring(0, 1));
                }
                else
                {
                    sb.Append(key);
                }

                string finalKey = prevKey + key.Substring(0, 1);

                if (this.dict.ContainsKey(finalKey) == false)
                {
                    this.dict[finalKey] = this.dict.Count;
                }

                if (Convert.ToString(this.dict.Count, 2).Length > this.codeLen)
                    this.codeLen++;

                prevValue = value;
            }

            return sb.ToString();
        }

    }
}