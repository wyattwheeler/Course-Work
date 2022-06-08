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
    public partial class Form2 : Form
    {
        public class Registration
        {
            public string? sUsername { get; set; }
            public string? sPassword { get; set; }
            public string? sEmail { get; set; }
            public string? sBirthday { get; set; }
            public string? sMobile { get; set; }
        }

        public bool bHighConstrastMode;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bHighConstrastMode = false;

            Random random = new Random();
            int iNum = random.Next(6, 8);

            string sCaptcha = "";

            int iTotal = 0;

            do
            {
                int chr = random.Next(48, 123);

                // public resource tingz
                if((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    sCaptcha = sCaptcha + (char)chr;

                    iTotal++;

                    if (iTotal == iNum)
                        break;
                }
            } while (true);
            label11.Text = sCaptcha;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label11.Text != textBox9.Text)
                MessageBox.Show("Invalid Captcha!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!bHighConstrastMode)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;

                textBox10.ForeColor = Color.White;
                textBox10.BackColor = Color.Black;

                foreach (Button b in Controls.OfType<Button>())
                {
                    b.ForeColor = Color.Black;
                }

                bHighConstrastMode = true;
            }
            else if(bHighConstrastMode)
            {
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;

                bHighConstrastMode = false;
            }
        }
    }
}
