using System;
using System.Windows.Forms;

namespace Crypto_Lab04
{
    public partial class Form1 : Form
    {
        int state;
        int[] key;

        public Form1()
        {
            InitializeComponent();
            state = 1;
            int[] k = { 2, 5, 4, 3, 1 };
            key = k;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int[] getunkey(int[] array)
        {
            int[] res = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                res[array[i] - 1] = i + 1;
            }
            return res;
        }
        string crypt(string msg, bool flag)
        {
            string tmp1;
            string tmp2;
            int[] k;

            if (flag)
            {
                k = key;
            }
            else
            {
                k = getunkey(key);
            }

            string result = "";
            for (int i = 0; i < (1 + (msg.Length / k.Length)); i++)
            {

                if ((i + 1) * k.Length > msg.Length)
                {
                    return result += msg.Substring(i * k.Length, msg.Length - (i * k.Length));
                }
                tmp1 = msg.Substring(i * k.Length, k.Length);
                tmp2 = "";
                for (int n = 0; n < k.Length; n++)
                {
                    tmp2 += tmp1.Substring(k[n] - 1, 1);
                }
                result += tmp2;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (state)
            {
            case 1:
                {
                    groupBox1.Text = "Криптограмма";
                    button1.Text = "Расшифровать";
                    textBox1.Text = crypt(textBox1.Text, true);
                    state = 2;
                    break;
                }

                case 2:
                {
                    groupBox1.Text = "Исходный текст";
                    button1.Text = "Зашифровать";
                    textBox1.Text = crypt(textBox1.Text, false);
                    state = 1;
                    break;
                }
                default:
                {
                    MessageBox.Show("Error");
                    break;
                }
            }
        }
    }
}