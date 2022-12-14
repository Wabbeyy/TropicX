using DiscordRpcDemo;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WeAreDevs_API;

namespace TropicX
{
    public partial class Form1 : Form
    {
        ExploitAPI TropicX = new ExploitAPI();

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public Form1()
        {
            InitializeComponent();
        }

        Point lastPoint;

        private void button1_Click(object sender, EventArgs e)
        {
            TropicX.LaunchExploit();
            Status.Text = "Injecter: ✔";
            Status.ForeColor = Color.Chartreuse;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1023555743309385788", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1023555743309385788", ref this.handlers, true, null);
            this.presence.details = "TropicX Exploit";
            this.presence.state = "Version 1.0.0";
            this.presence.largeImageKey = "logo";
            this.presence.smallImageKey = "logo-small";
            this.presence.largeImageText = "TropicX Exploit";
            this.presence.smallImageText = "Version 1.0.0";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;
            TropicX.SendLimitedLuaScript(script);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void folder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void openfl_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }
    }
}
