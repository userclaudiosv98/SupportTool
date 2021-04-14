using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace SupportTool
{
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e){
            Process.Start("https://www.youtube.com/watch?v=bUTK1qjL_kY&list=RDbUTK1qjL_kY&start_radio=1");
        }

        private void button1_Click(object sender, System.EventArgs e){
            var endPoint = "https://api.ipify.org/";
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            var response = (HttpWebResponse)request.GetResponse();
            var resStream = response.GetResponseStream();
            var streamReader = new StreamReader(resStream);
            button1.Text = $"IP Público: {streamReader.ReadToEnd()}";
        }

        private void button2_Click(object sender, System.EventArgs e){
            IPHostEntry host;
            var localIP = string.Empty;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString().Equals("InterNetwork"))
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            button2.Text = $"IP Interno: {localIP}";
        }
    }
}
