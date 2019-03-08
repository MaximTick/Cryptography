using System.Collections.Generic;

namespace Crypto_Lab03
{
    class Caesar : List<Clent>
    {
        public Caesar()
        { 
            Add(new Clent("abcdefghijklmnopqrstuvwxyz"));
            Add(new Clent("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Add(new Clent("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            Add(new Clent("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            Add(new Clent("0123456789"));
            Add(new Clent("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }

        public string CaesarChipher(string message, int key)
        {
            string res = "";
            string tmp = "";
            for (int i = 0; i < message.Length; i++)
            {
                foreach (Clent v in this)
                {
                    tmp = v.Change(message.Substring(i, 1), key);
                    if (tmp != "")  
                    {
                        res += tmp;
                        break;  
                    }
                }
                if (tmp == "")
                    res += message.Substring(i, 1);
            }
            return res;
        }
    }
}
