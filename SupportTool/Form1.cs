using System.Windows.Forms;
using System.Diagnostics;

namespace SupportTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Clicou no link.");
            Process.Start("https://www.youtube.com/");
        }
    }
}
