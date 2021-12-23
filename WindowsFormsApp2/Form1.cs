using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string Code = "{Occupants:[";
        public Form1()
        {
            if(!File.Exists("./Siticone.Desktop.UI.dll"))
            {
                WebClient wb = new WebClient();    
                MessageBox.Show("Error, Couldnt find DLL, Running Auto-Download", "CBE Maker");
                wb.DownloadFile("https://cdn.discordapp.com/attachments/922998843967143979/922998923784765440/Siticone.Desktop.UI.dll", @"Siticone.Desktop.UI.dll");
            }
            if(!Directory.Exists("C:/CBEMaker"))
            {
                WebClient wb = new WebClient();
                Directory.CreateDirectory("C:/CBEMaker");
                MessageBox.Show("Looks like it's your first time! Getting things ready for you.");
                wb.DownloadFile("https://cdn.discordapp.com/attachments/922998843967143979/922998923784765440/Siticone.Desktop.UI.dll", @"Siticone.Desktop.UI.dll");
            }
            else
            if(!File.Exists("C:/CBEMaker/isOpened.dll"))
            {
                WebClient wb = new WebClient();
                MessageBox.Show("Looks like it's your first time! Getting things ready for you.");
                wb.DownloadFile("https://cdn.discordapp.com/attachments/922998843967143979/922998923784765440/Siticone.Desktop.UI.dll", @"Siticone.Desktop.UI.dll");
            }
            File.Create("C:/CBEMaker/isOpened.dll");
            InitializeComponent();
        }
        Point lastPoint;
        private void button1_Click(object sender, EventArgs e)
        {
            const string quote = "\"";
            if(Code.Contains("TicksLeftToStay:0}}"))
            {
                Code = Code + ",";
            }
            Code = Code + "{ActorIdentifier:" + quote + "minecraft:command_block_minecart<>" + quote + ",SaveData:{Command:" + quote + textBox1.Text + quote + ",Persistent:1b,Ticking:1b,TicksLeftToStay:0}}";
            MessageBox.Show("Command Added", "CBE Maker");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Code = "{Occupants:[";
        }

        private void button2_Click(object sender, EventArgs e)
        {       
            if(textBox3.Text == "Item Name")
            {
                textBox3.Text = "Custom Command Block Exploit";
            }
            if(textBox4.Text == "Lore")
            {
                textBox4.Text = "A NBT made with CBE Maker, By Wylx.";
            }
            const string quote = "\"";
          
            Code = Code + "]" + ",display:{Lore:[" + quote + textBox4.Text + quote + "],Name:" + quote + textBox3.Text + quote + "},ench:[{id:17s,lvl:21s}]}";
            textBox2.Text = Code;
            Clipboard.SetText(Code);
            Code = "{Occupants:[";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Code == "{Occupants:[")
            {
                if (textBox2.Text.Contains("{Occupants:[]"))
                {
                    MessageBox.Show("No code to save!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("No code to save!");
                }
                else if (textBox2.Text == "Output")
                {
                    MessageBox.Show("No code to save!");
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(textBox2.Text);
                        }
                        MessageBox.Show("Code Saved.");
                    }
                }
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(Code);
                    }
                    MessageBox.Show("Code Saved.");
                }
            }
        }
    }
}
