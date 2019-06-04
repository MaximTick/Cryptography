using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab11.LZ
{
    public class LZWEncoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        Ansi table = null;
             
        int codeLen = 8;
        public LZWEncoder()
        {
            this.table = new Ansi();
            this.dict = this.table.Table;
        }

        public string EncodeToCodes(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;                

                while (this.dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (this.dict.ContainsKey(w) == false)                
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(this.dict[matchKey] +  ", ");

                    this.dict.Add(w, this.dict.Count);
                    i--;
                }
                else 
                {
                    sb.Append(this.dict[w] + ", ");
                }
            }

            return sb.ToString(); 
        }

        public string Encode(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;

                while (this.dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (this.dict.ContainsKey(w) == false)                
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(Convert.ToString(this.dict[matchKey], 2).FillWithZero(this.codeLen));

                    if (Convert.ToString(this.dict.Count, 2).Length > this.codeLen)
                        this.codeLen++;

                    this.dict.Add(w, this.dict.Count);
                    i--;
                }
                else
                {                    
                    sb.Append(Convert.ToString(this.dict[w], 2).FillWithZero(this.codeLen));

                    if (Convert.ToString(this.dict.Count, 2).Length > this.codeLen)
                        this.codeLen++;                 
                }
            }
            return sb.ToString();
        }

        public byte[] EncodeToByteList(string input)
        {
            string encodedInput = this.Encode(input);
            return encodedInput.ToByteArray();
        }

    }
}
