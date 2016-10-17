using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace security_app
{
    public partial class Form1 : Form
    {
        user User = user.getInstance();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123") {
                User.AccessLevel = "admin";
                label3.Text = "Logged in as " + User.AccessLevel;
                richTextBox1.Visible = true;
            }
            else if (textBox1.Text == "manager" && textBox2.Text == "123")
            {
                User.AccessLevel = "manager";
                label3.Text = "Logged in as " + User.AccessLevel;
                richTextBox1.Visible = true;
            }
            else if (textBox1.Text == "driver" && textBox2.Text == "123")
            {
                User.AccessLevel = "driver";
                label3.Text = "Logged in as " + User.AccessLevel;
                richTextBox1.Visible = true;
            }
            else if (textBox1.Text == "client" && textBox2.Text == "123")
            {
                User.AccessLevel = "client";
                label3.Text = "Logged in as " + User.AccessLevel;
                richTextBox1.Visible = true;
            }
            else {
                User.AccessLevel = "notLoggedIn";
                label3.Text = "wrong credentials!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                file openFile = new file(file);
                
                try
                {
                    richTextBox1.Text = File.ReadAllText(openFile.UrlPath);
                }
                catch (IOException)
                {
                }
            }
        }

    }
}
