using System;
using System.Windows.Forms;

namespace Crypto_Lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Caesar caesar = new Caesar();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = caesar.CaesarChipher(textBox1.Text, Convert.ToInt32(numericUpDown1.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = caesar.CaesarChipher(textBox2.Text, Convert.ToInt32(-numericUpDown1.Value));

        }
    }
}
