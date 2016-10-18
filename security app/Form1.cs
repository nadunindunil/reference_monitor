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
        user User;
        file openFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = authorize.auth(textBox1.Text, textBox2.Text);

            if (authorize.auth(textBox1.Text, textBox2.Text) != "false")
            {
                User = new user(textBox1.Text, Int32.Parse(authorize.auth(textBox1.Text, textBox2.Text)));
                label3.Text = "logged in as " + User.Name;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
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
                openFile = new file(file);
               
                if (referenceMonitor.readability(openFile, User))
                {
                    Console.WriteLine("in if");
                    try
                    {
                        richTextBox1.Text = File.ReadAllText(openFile.UrlPath);
                        Console.WriteLine(File.ReadAllText(openFile.UrlPath));
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("no read access!");
                    richTextBox1.Text = "file is open but no read access";
                    MessageBox.Show("You user level hasn't read access for the file","Message");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            User = null;
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "";
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (referenceMonitor.writabiliy(openFile, User))
            {
                richTextBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("You don't have rights to write this file!", "Message");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (referenceMonitor.writabiliy(openFile, User))
            {
                File.WriteAllText(openFile.UrlPath, richTextBox1.Text);
                MessageBox.Show("file was edited", "Message");
            }
            else
            {
                MessageBox.Show("You don't have rights to write this file!", "Message");
            }
        }
    }
}
