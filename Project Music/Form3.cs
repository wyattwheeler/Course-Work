using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMusic
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label6.Text != textBox3.Text)
                MessageBox.Show("Invalid Captcha!");
            else
            {
                this.Hide();
                new Form1().Show();

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int iNum = random.Next(6, 8);

            string sCaptcha = "";

            int iTotal = 0;

            do
            {
                int chr = random.Next(48, 123);

                // public resource tingz
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    sCaptcha = sCaptcha + (char)chr;

                    iTotal++;

                    if (iTotal == iNum)
                        break;
                }
            } while (true);
            label6.Text = sCaptcha;
        }
    }
}
