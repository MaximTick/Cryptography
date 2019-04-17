using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElGamal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороку для зашифрования");
            var str = Console.ReadLine();

            Console.WriteLine("El-Gamal");
            var elgamalCrypted = ElGamal.EnCrypt(str);
            Console.WriteLine("Зашифрованная строка = " + elgamalCrypted);
            var elgamalDecrypted = ElGamal.DeCrypt(elgamalCrypted);
            Console.WriteLine("decrypted = " + elgamalDecrypted);

            Console.ReadLine();
        }
    }
}
