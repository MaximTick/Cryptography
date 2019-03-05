using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace Crypto_Lab02
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            Shannon shannon = new Shannon();
            string pathBytes = "bytes.txt";
            string path = "rfc2616.txt";

            string rfc2616;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            { rfc2616 = sr.ReadToEnd(); }
            string patternRU = @"[A-Za-z0-9\s+\W_]";
            string patternEN = @"[А-Яа-я0-9\s+\W_]";
            string patternBIN = @"\s+";
            string target = "";

            Regex regexRU = new Regex(patternRU, RegexOptions.IgnoreCase);
            Regex regexEN = new Regex(patternEN);
            Regex regexBIN = new Regex(patternBIN);

            string resultRU = regexRU.Replace(rfc2616, target);
            string resultEN = regexEN.Replace(rfc2616, target);
            string resultBIN = regexBIN.Replace(rfc2616, target);

            //Console.WriteLine("RUS Энтропия по Шеннону фразы = " + shannon.ShannonEntropy(resultRU.ToLower()));
            Console.WriteLine("ENG Энтропия по Шеннону фразы = " + shannon.ShannonEntropy(resultEN.ToLower()));

            //task 2
            StringBuilder builder = new StringBuilder();
            foreach(char a in resultBIN)            
                builder.Append(Convert.ToString(a, 2));

            using (StreamWriter sw = new StreamWriter(pathBytes, false, Encoding.Default))
            { sw.Write(builder); }
            Console.WriteLine("Binary Энторопия по Шенону = " + shannon.ShannonEntropy(builder.ToString()));

            //Console.WriteLine(rfc2616);
            //Console.WriteLine(builder.ToString());
            //Console.WriteLine(resultBIN.ToString());

            //task 3
            String myName = "Tikhonovich Maxim Alexandrovich";
            string patternName = @"\s+";
            Regex regexName = new Regex(patternName);
            string resulName = regexName.Replace(myName, target);
            double shann = shannon.ShannonEntropy(resultEN.ToLower());
            Console.WriteLine($"Количество информации в ФИО {shannon.AmountOfInformation(resulName, shann)}");
            Console.WriteLine(resulName);

            byte[] bytes = Encoding.ASCII.GetBytes(resulName);
            String ASCII = "";
            foreach (var b in bytes)
                ASCII += b;

            //хз каку энтропию для ASCII брать
            Console.WriteLine("ASCII: Кол-во инф-ции в ФИО " + shannon.AmountOfInformation(ASCII, shann));

            //task4
            Console.WriteLine("С условной вероятностью ошибки 0,1 " + shannon.AmountOfInformationWithMistake(resulName, 0.9));
            Console.WriteLine("С условной вероятностью ошибки 0,5 " + shannon.AmountOfInformationWithMistake(resulName, 0.5));
            Console.WriteLine("С условной вероятностью ошибки 1 " + shannon.AmountOfInformationWithMistake(resulName, 1));

            Console.ReadLine();
        }
    }
}
