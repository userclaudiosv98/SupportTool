using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System;
using System.Management;
using System.Linq;
using System.Net.NetworkInformation;

namespace SupportTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Eventos
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=RLQlaYqI_G4");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var endPoint = "https://api.ipify.org/";
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            var response = (HttpWebResponse)request.GetResponse();
            var resStream = response.GetResponseStream();
            var streamReader = new StreamReader(resStream);
            button1.Text = $"IP Público: {streamReader.ReadToEnd()}";
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            button2.Text = $"IP Interno: {getIpAddres()}";
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }

            button3.Text = result.Replace("Microsoft", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').First();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = getPing();
        }

        //Funções
        private static string getIpAddres()
        {
            IPHostEntry host;
            var localIP = string.Empty;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString().Equals("InterNetwork"))
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }

        private static string getPing()
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = getIpAddres();
            r = p.Send(s);

            if (r.Status == IPStatus.Success)
            {
                return "Ping to " + s.ToString() + "[" + r.Address.ToString() + "]" + " Successful" + " Response delay = " + r.RoundtripTime.ToString() + " ms";
            }
            else
            {
                return "Failed";
            }
        }
    }
}