using Crypto_Lab11.LZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab11
{
    public class LzClass
    {
        static string _fileToCompress = @"lz.txt";
        static string _encodedFile = @"TestOutput.txt";
        static string _decodedFile = @"TestDecodedOutput.txt";

        public static void Do()
        {
            Console.WriteLine("Generate ANSI table ...");
            var ascii = new Ansi();
            ascii.WriteToFile();
            Console.WriteLine("ANSI table generated.");
            Console.WriteLine("Start encoding " + _fileToCompress + " ...");
            var text = File.ReadAllText(_fileToCompress);
            var encoder = new LZWEncoder();
            var b = encoder.EncodeToByteList(text);
            File.WriteAllBytes(_encodedFile, b);
            Console.WriteLine("File " + _fileToCompress + " encoded to " + _encodedFile);
            Console.WriteLine("Start decoding " + _encodedFile);
            var decoder = new LZWDecoder();
            var bo = File.ReadAllBytes(_encodedFile);
            var decodedOutput = decoder.DecodeFromCodes(bo);
            File.WriteAllText(_decodedFile, decodedOutput, Encoding.Default);
            Console.WriteLine("File " + _encodedFile + " decoded to " + _decodedFile);
        }
    }
}
