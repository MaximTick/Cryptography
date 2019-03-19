using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace VegenerChipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Vegener vegener = new Vegener();
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {        
            if (textBoxKeyWord.Text.Length > 0)
            {
                    string s;

                    StreamReader sr = new StreamReader("in.txt", Encoding.GetEncoding(1251));
                    StreamWriter sw = new StreamWriter("out.txt", true, Encoding.GetEncoding(1251));

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(vegener.Encode(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                    MessageBox.Show("Сообщение зашифровано");
            }
                else
                    MessageBox.Show("Введите ключевое слово!");
            
        }

        private void buttonDecipher_Click(object sender, EventArgs e)
        {                       
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s;

                    StreamReader sr = new StreamReader("out.txt", Encoding.GetEncoding(1251));
                    StreamWriter sw = new StreamWriter("decode.txt", true, Encoding.GetEncoding(1251));

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(vegener.Decode(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                    MessageBox.Show("Сообщение расшифровано");
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            
        }
    }
}
