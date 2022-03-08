using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCharlie
{
    public partial class Form1 : Form
    {
        public string sMeetingAimLazy { get; set; }
        public string sMeetingWithLazy { get; set; }
        public class Meeting
        {
            public string sName { get; set; }
            public string sSurname { get; set; }
            public string sMobile { get; set; }
            public string sEmail { get; set; }
            public string sTime { get; set; }
            public string sDate { get; set; }
            public int iMeetingAimID { get; set; }
            public string sMeetingWith { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public List<Meeting> MeetingList = new List<Meeting>();
        public List<string> NameList = new List<string>();

        private bool FormErrors()
        {
            // Textboxes
            if (textBox1.Text.Trim() == String.Empty)
                return true;
            if (textBox2.Text.Trim() == String.Empty)
                return true;
            if (textBox3.Text.Trim() == String.Empty)
                return true;
            if (textBox4.Text.Trim() == String.Empty)
                return true;

            // Textbox usage
            if (!Int32.TryParse(textBox3.Text, out int iText))
                return true;

            // Let us check for a valid email
            if (textBox4.Text.Length > 0)
            {
                try
                {
                    string s = textBox4.Text;
                    MailAddress ma = new MailAddress(s);

                    return false;
                }
                catch
                {
                    return true;
                }
            }

            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // let's use that bool we made at the top, cleanliness
            if (FormErrors())
            {
                MessageBox.Show("Invalid usage of form, please check for errors.");
            }
            else
            {
                Meeting meeting = new Meeting();

                meeting.sName = textBox1.Text;
                meeting.sSurname = textBox2.Text;
                meeting.sMobile = textBox3.Text;
                meeting.sEmail = textBox4.Text;
                meeting.sDate = dateTimePicker1.Text;
                meeting.iMeetingAimID = Form2.iChosen;
                meeting.sTime = dateTimePicker2.Text;
                meeting.sMeetingWith = sMeetingWithLazy; // HARDCODE NAMES BECAUSE TIME IS MONEY!

                string sFullName = String.Format("{0} {1}", meeting.sName, meeting.sSurname);
                NameList.Add(sFullName);

                string sMeetingAim = "";

                MeetingList.Add(meeting);

                switch(meeting.iMeetingAimID)
                {
                    case 1:
                        {
                            sMeetingAim = "Meeting";
                            break;
                        }
                    case 2:
                        {
                            sMeetingAim = "Sales Appointment";
                            break;
                        }
                    case 3:
                        {
                            sMeetingAim = "Site Visit";
                            break;
                        }
                    case 4:
                        {
                            sMeetingAim = "Student Interview";
                            break;
                        }
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = NameList;
                comboBox2.DataSource = bs;

                sMeetingAimLazy = sMeetingAim;

                VisitorList.Items.Clear();

                ClearForm();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show(); // efficient
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm tt";
            dateTimePicker2.ShowUpDown = true;

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Form2.iChosen = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Form2.iChosen)
            {
                case 0:
                    {
                        button2.Text = "Meeting Aim";
                        break;
                    }
                case 1:
                    {
                        button2.Text = "Meeting";
                        break;
                    }
                case 2:
                    {
                        button2.Text = "Sales Appointment";
                        break;
                    }
                case 3:
                    {
                        button2.Text = "Site Visit";
                        break;
                    }
                case 4:
                    {
                        button2.Text = "Student Interview";
                        break;
                    }
            }

            switch(comboBox1.SelectedText)
            {
                case "John Doe":
                    {
                        sMeetingWithLazy = "John Doe";
                        break;
                    }
                case "Mike Hunt":
                    {
                        sMeetingWithLazy = "Mike Hunt";
                        break;
                    }
                case "ZEZE":
                    {
                        sMeetingWithLazy = "ZEZE";
                        break;
                    }
                case "Not Applicable":
                    {
                        sMeetingWithLazy = "Not Applicable";
                        break;
                    }
            }

            VisitorList.Items.Clear();

            foreach(Meeting m in MeetingList)
            {
                VisitorList.Items.Add("===========================");
                VisitorList.Items.Add(String.Format("Meeting of: {0} {1}", m.sName, m.sSurname));
                VisitorList.Items.Add(String.Format("Meeting date: {0}", m.sDate));
                VisitorList.Items.Add(String.Format("Meeting at: {0}", m.sTime));
                VisitorList.Items.Add(String.Format("Meeting with: {0}", m.sMeetingWith));
                VisitorList.Items.Add(String.Format("Meeting aim: {0}", sMeetingAimLazy));
            }

        }

        private void VistorList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VisitorList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Delete)
            {
                if (VisitorList.Items.Count >= 1)
                    if (VisitorList.SelectedValue != null)
                        VisitorList.Items.RemoveAt(VisitorList.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sInput = comboBox1.Text;

            if(sInput != "")
            {
                NameList.Add(sInput);
            }

            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sEmployee = comboBox1.Text;
            bool isReal = NameList.Any(s => sEmployee.Contains(s));

            if(isReal)
                NameList.Remove(sEmployee);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Meeting mr = new Meeting();

            if(comboBox2.SelectedItem != null)
            {
                string sName = comboBox2.SelectedItem.ToString();
                NameList.Remove(sName);
                comboBox2.Text = "";

                BindingSource bs = new BindingSource();
                bs.DataSource = NameList;
                comboBox2.DataSource = bs;

                string[] subs = sName.Split(' ');

                var item = MeetingList.FirstOrDefault(meeting => meeting.sName == subs[0]);
                MeetingList.Remove(item);
            }
        }
    }
}
