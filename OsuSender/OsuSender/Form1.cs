using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace OsuSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string localweb = @"http://127.0.0.1:8079/osu";
        string UrlText = @"https://osu.ppy.sh/b/949456";
        string SongId = "949456";

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length <= 1)
                Application.Exit();

            foreach (string arg in args)
            {
                //analyse cmd line
                UrlText = arg;//temp
            }

            Regex r = new Regex(@"\d+");
            Match m = r.Match(UrlText);
            SongId = m.Value;

            try {
                Encoding encoding = Encoding.GetEncoding("utf-8");
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("SongId", SongId);
                HttpWebResponse response = OsuHttp.HttpWebResponseUtility.CreatePostHttpResponse(localweb, parameters, null, null, encoding, null);
                ;
            }
            catch(Exception ex)
            {
                ;
            }

            Thread.Sleep(10000);
            Application.Exit();
        }
        
    }
}
