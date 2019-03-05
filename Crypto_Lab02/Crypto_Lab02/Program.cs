using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Crypto_Lab02
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Shannon shannon = new Shannon();
            string path = @"D:\study3course\6thsem\Cryptography\Labs\test.txt";
            string s;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                s = sr.ReadToEnd();
                Console.WriteLine(s);
            }
            string pattern = @"[A-Za-z\s+\W]";
            string target = "";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            string result = regex.Replace(s, target);
            Console.WriteLine($"Энтропия по Шеннону фразы = " + shannon.ShannonEntropy(result.ToLower()));
            Console.WriteLine(result.ToLower());
        }
    }
}
