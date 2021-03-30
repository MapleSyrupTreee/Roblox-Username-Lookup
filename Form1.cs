using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Roblox_Username_Lookup
{
    public partial class Form1 : Form
    {

        string Username = "";

        string RBLXID = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen BlackPen = new Pen(Color.FromArgb(255, 0, 0, 0)); // Pen Color Black
            e.Graphics.DrawLine(
                BlackPen, // Use Black Pen
                261, 20, // Start Point
                261, 230 // End Point
                );
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.WebClient Web = new System.Net.WebClient();
                byte[] URL = Web.DownloadData("https://verify.eryn.io/api/user/" + textBox1.Text);

                string Source = System.Text.Encoding.UTF8.GetString(URL);

                dynamic ParsedJSON = JsonConvert.DeserializeObject(Source);

                Username = ParsedJSON.robloxUsername;

                RBLXID = ParsedJSON.robloxId;

                label1.Text = "Roblox Username: " + Username;

                label2.Text = "Roblox ID: " + RBLXID;
            }
            catch (WebException Error)
            {
                MessageBox.Show("That user doesnt have a roblox account or has never used roblox verification bot!");
            }
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Copied Username To Clipboard");
            Clipboard.SetText(Username);
        }

        private void Label2_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Copied RobloxID To Clipboard");
            Clipboard.SetText(RBLXID);
        }
    }
}
