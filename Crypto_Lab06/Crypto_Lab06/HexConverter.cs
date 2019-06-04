using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab06
{
    public static class HexConverter
    {
        public static string HexToBinary(string hexstring)
        {
            string binarystring = String.Join(String.Empty,
              hexstring.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

            return binarystring;
        }

        public static string IntToHex(int value)
        {
            return value.ToString("X");
        }

        public static string IntToBinary(int value)
        {
            return Convert.ToString(value, 2);
        }

        public static int HexToInt(string hex)
        {
            return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }

        public static string BinaryToHex(string binary)
        {
            var result = new StringBuilder(binary.Length / 8 + 1);

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to Length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        public static string StrToHex(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
                sb.Append(t.ToString("X2"));

            return sb.ToString();
        }

        public static string HexStrToStr(string hexStr)
        {
            var bytes = new byte[hexStr.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);

            return Encoding.Unicode.GetString(bytes);
        }

        public static string BitsToHex(int[] bits)
        {
            string hex = string.Empty;
            for (int i = 0; i < bits.Length; i += 4)
            {
                string output = string.Empty;
                for (int j = 0; j < 4; j++)
                {
                    output += bits[i + j];
                }
                hex += Convert.ToInt32(output, 2).ToString("X");
            }

            return hex;
        }

        public static string BitsToHex(List<int[]> list)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                string binary = BitsToHex(list[i]);
                builder.Append(binary);
            }

            return builder.ToString();
        }
    }
}
