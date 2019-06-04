using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Lab06
{
    public static class Extensions
    {
        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            if (s == null)
                throw new ArgumentNullException("");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static int[] TrimEnd(this int[] array, int value)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            List<int> list = new List<int>(array);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == value)
                    list.RemoveAt(i);
                else
                    break;
            }

            return list.ToArray();
        }
    }
}
