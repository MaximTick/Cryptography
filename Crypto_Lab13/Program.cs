using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crypto_Lab13
{
    class Program
    {
        static void Main()
        {
            Ell.Do();
            Console.ReadLine();
        }
    }

    public static class Ell
    {
        private static byte[] _key;

        public static bool Veryify(byte[] data, byte[] signature)
        {
            using (ECDsaCng ecsdKey = new ECDsaCng(CngKey.Import(_key, CngKeyBlobFormat.EccPublicBlob)))
            {
                return ecsdKey.VerifyData(data, signature);
            }
        }
        public static void Do()
        {
            Console.WriteLine("File: ");
            WithFile(@"D:\study3course\6thsem\Cryptography\Labs\Crypto_Lab13\Test.txt");
            Console.WriteLine("String:");
            WithString("Hello world from CHN");
        }

        private static void WithString(string str)
        {
            var bytes = Encoding.Default.GetBytes(str);
            var sign = GetSign(bytes);
            Console.WriteLine("Signature = " + Encoding.Default.GetString(sign));

            Console.WriteLine("Veryify: ");
            Console.WriteLine(Veryify(bytes, sign));
        }

        private static void WithFile(string path)
        {
            var file = File.ReadAllLines(path).GetHashCode();
            var bytes = Encoding.Default.GetBytes(file.ToString());
            var sign = GetSign(bytes);
            Console.WriteLine("Signature = " + Encoding.Default.GetString(sign));

            Console.WriteLine("Veryify: ");
            Console.WriteLine(Veryify(bytes, sign));
        }

        private static byte[] GetSign(byte[] data)
        {
            using (ECDsaCng dsa = new ECDsaCng())
            {
                dsa.HashAlgorithm = CngAlgorithm.Sha256;
                _key = dsa.Key.Export(CngKeyBlobFormat.EccPublicBlob);
                byte[] signature = dsa.SignData(data);
                return signature;
            }
        }
    }
}