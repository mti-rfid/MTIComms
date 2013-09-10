using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTIComms;


namespace Tester
{
    public partial class Form1 : Form
    {
        RFIDReader myComms = new RFIDReader();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboxReader.SelectedIndex = 0;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                string result = myComms.Connect(cboxReader.Text);
                listBox1.Items.Add(result);
                btnWrite.Enabled = true;
                btnConnect.Text = "Disconnect";
            }
            else
            {
                btnConnect.Text = "Connect";
                btnWrite.Enabled = false;
                listBox1.Items.Add(myComms.Disconnect());
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            byte[] success = myComms.write(textBox1.Text, Convert.ToInt16(textBox2.Text));
            string result = "";
            foreach (byte mybyte in success)
                result += mybyte.ToString() + " ";

            listBox1.Items.Add(result);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myComms.About());
        }



    }
}
