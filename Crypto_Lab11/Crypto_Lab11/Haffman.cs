using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crypto_Lab11
{
    public static class Haffman
    {
        class Node
        {
            private char[] _chars;
            private int _value;
            private Node _a;
            private Node _b;


            public char[] Chars
            {
                get { return this._chars; }
                set { this._chars = value; }
            }

            public int Value
            {
                get { return this._value; }
                set { this._value = value; }
            }

            public Node A
            {
                get { return this._a; }
                set { this._a = value; }
            }

            public Node B
            {
                get { return this._b; }
                set { this._b = value; }
            }

            public bool IsEnd
            {
                get { return this._chars.Length == 1; }
            }


            public Node(char chr, int value)
            {
                this._chars = new char[1] { chr };
                this._value = value;
            }

            public Node(Node a, Node b)
            {
                this._a = a;
                this._b = b;
                this._value = a.Value + b.Value;
                this.Chars = new char[a.Chars.Length + b.Chars.Length];
                Array.Copy(a.Chars, 0, this._chars, 0, a.Chars.Length);
                Array.Copy(b.Chars, 0, this._chars, a.Chars.Length, b.Chars.Length);
            }
        }

        static int min_node(Node[] nodes, int ignore)
        {
            Node node = null;
            int index = 0;
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i] != null && i != ignore)
                {
                    node = nodes[i];
                    index = i;
                    break;
                }
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i] != null && i != ignore && nodes[i].Value < node.Value)
                {
                    node = nodes[i];
                    index = i;
                }
            return index;
        }

        static void Calc(string text, out char[] chars, out int[] counts)
        {
            HashSet<char> charsSet = new HashSet<char>();

            foreach (char c in text)
                charsSet.Add(c);

            chars = charsSet.ToArray();
            counts = new int[chars.Length];

            foreach (char c in text)
                for (int i = 0; i < chars.Length; i++)
                    if (chars[i] == c)
                        counts[i]++;
        }

        static void Sort(char[] chars, int[] counts)
        {
            for (int i = chars.Length; i > 0; i--)
                for (int j = 0; j < i - 1; j++)
                    if (counts[j] > counts[j + 1])
                    {
                        char chr = chars[j];
                        chars[j] = chars[j + 1];
                        chars[j + 1] = chr;
                        int n = counts[j];
                        counts[j] = counts[j + 1];
                        counts[j + 1] = n;
                    }
        }

        static Node Tree(char[] chars, int[] counts)
        {
            Node[] nodes = new Node[chars.Length];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node(chars[i], counts[i]);

            do
            {
                int aIndex = min_node(nodes, -1);
                int bIndex = min_node(nodes, aIndex);
                Node c = new Node(nodes[aIndex], nodes[bIndex]);
                nodes[aIndex] = c;
                nodes[bIndex] = null;

                int count = 0;
                foreach (var t in nodes)
                {
                    if (t != null)
                    {
                        count++;
                    }
                }

                if (count == 1)
                    break;
            }
            while (true);

            Node node = null;
            foreach (var t in nodes)
            {
                if (t != null)
                {
                    node = t;
                    break;
                }
            }

            return node;
        }

        static bool[] calc_code(Node node, char c)
        {
            bool[] code = new bool[0];

            while (true)
            {
                if (node.IsEnd)
                    break;
                Array.Resize(ref code, code.Length + 1);
                if (node.A.Chars.Contains(c))
                {
                    node = node.A;
                    code[code.Length - 1] = false;
                }
                else
                {
                    node = node.B;
                    code[code.Length - 1] = true;
                }
            }
            return code;
        }

        static bool[] Encode(string text, out Node node)
        {
            char[] chars;
            int[] counts;
            Calc(text, out chars, out counts);
            Sort(chars, counts);
            node = Tree(chars, counts);

            bool[] encodedText = new bool[0];
            for (int i = 0; i < text.Length; i++)
            {
                bool[] code = calc_code(node, text[i]);
                int length = encodedText.Length;
                Array.Resize(ref encodedText, length + code.Length);
                Array.Copy(code, 0, encodedText, length, code.Length);
            }

            return encodedText;
        }

        static string Decode(bool[] encodedText, Node node)
        {
            Node nodeA = node;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encodedText.Length;)
            {
                while (!node.IsEnd)
                {
                    if (encodedText[i++])
                        node = node.B;
                    else
                        node = node.A;
                }
                builder.Append(node.Chars[0]);
                node = nodeA;
            }
            return builder.ToString();
        }

        public static void Do()
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            bool[] encodedText = Encode(text, out var node);
            foreach (bool b in encodedText)
                Console.Write(b ? "1" : "0");
            Console.WriteLine();
            string decodedText = Decode(encodedText, node);
            Console.WriteLine(decodedText);
            Console.ReadKey();
        }
    }
}