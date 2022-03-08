using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCharlie
{
    public partial class Form2 : Form
    {
        bool CheckRadios(Control container)
        {
            foreach(var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                    return true;

            }

            return false;
        }

        public static int iChosen { get; set; }

        RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                    return radio;

            }

            return null;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!CheckRadios(this))
            {
                MessageBox.Show("Please select aim of meeting.");
            }
            else
            {
                RadioButton selected = GetCheckedRadio(this);

                // only the best switch statement you'll ever see
                switch(selected.Name)
                {
                    case "radioButton1":
                        {
                            iChosen = 1;
                            break;
                        }
                    case "radioButton2":
                        {
                            iChosen = 2;
                            break;
                        }
                    case "radioButton3":
                        {
                            iChosen = 3;
                            break;
                        }
                    case "radioButton4":
                        {
                            iChosen = 4;
                            break;
                        }
                }

                this.Close();
            }
        }
    }
}
