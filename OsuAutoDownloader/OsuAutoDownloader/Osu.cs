using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OsuAutoDownloader
{
    class Osu
    {
        private string OsuUrlHead = "https://osu.ppy.sh/b/";
        public string UrlHead = "http://osu.mengsky.net/api/download/";
        private string Index = "477640";//haha
        private string SongId = "387700";//haha
        public Osu (string index)
        {
            if (index.Length != 6)
            {
                throw new Exception("length error");//temp
            }
            Index = index;
        }

        public enum DownStatue
        {
            Ok,
            Error,
        };

        public void GetSongId ()
        {
            WebClient downloader = new WebClient();
            try
            {
                string html = Encoding.UTF8.GetString(downloader.DownloadData(new Uri(OsuUrlHead + Index)));//change async later
                Regex r = new Regex(@"s=(\d{6})");
                Match m = r.Match(html);
                SongId = m.Groups[1].Value;
                Console.WriteLine("SongId:{0}", m.Groups[1].Value);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

//         private void downloaderProcessChange (object sender,DownloadProgressChangedEventArgs e)
//         {
//             Console.Write("\r{0}\t{1}/{2}", e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive);
//         }
// 
//         private void downloaderFinish(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
//         {
//             Console.WriteLine("finish!");
//             downfinish = true;
//         }

       // bool downfinish = false;
        public DownStatue SongDownload()
        {
            try
            {
                /*WebClient downloader = new WebClient();*/
                Uri u = new Uri(UrlHead + SongId);
                //                 downloader.DownloadFileCompleted += downloaderFinish;
                //                 downloader.DownloadProgressChanged += downloaderProcessChange;
                //                 Console.WriteLine(u.AbsoluteUri);
                //                 downloader.DownloadFileAsync(u,"osu.osz");
                //                 while (!downfinish) ;
                //Process p = Process.Start("wget", "-O osu.osz " + u.AbsoluteUri);
                Process p = new Process();
                p.StartInfo.FileName = "wget";
                p.StartInfo.Arguments = "-O osu.osz " + u.AbsoluteUri;
                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.WaitForExit(60000);
                p.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DownStatue.Error;
            }

            return DownStatue.Ok;
        }
    }
}
