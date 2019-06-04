using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab06
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string inputHex = "123456ABCD132531";
            string inputHex1 = "123456";
            string inputHex2 = "123456ABCD132536ADDE23";
            string keyHex = TripleDES.GetRandomKeyHex();

            //string cipher = TripleDES.Encrypt(keyHex, inputHex1);
            //Console.WriteLine(cipher);

            //string decrypted = TripleDES.Decrypt(keyHex, cipher);
            //Console.WriteLine(decrypted);

            //Console.WriteLine(keyHex);
            //Console.ReadKey();

            DES des = new DES();
            string deschiper = des.Encrypt(keyHex, inputHex);
            string decryptchiper = DES.Decrypt(keyHex, deschiper);
            Console.ReadKey();
        }
    }
}