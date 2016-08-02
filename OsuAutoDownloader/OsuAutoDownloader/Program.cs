using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OsuAutoDownloader
{
    class Program
    {
        /// <summary>
        /// show help in cmd line
        /// </summary>
        static private void HelpShow ()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\t\tOsuAutoDownload.exe Url\n");

            Console.WriteLine("eg:");
            Console.WriteLine("\t\tOsuAutoDownload.exe https://osu.ppy.sh/s/477640");
        }
        /// <summary>
        /// main func
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0)//temp change this line later
                HelpShow();

            Regex r = new Regex(@"https*://osu.ppy.sh/b/(\d{6})");

            foreach (string arg in args)
            {
                Console.WriteLine(arg);
                try
                {
                    Match m = r.Match(arg);
                    string osuIndex = m.Groups[1].Value;
                    Console.WriteLine(osuIndex);
                    Osu osu = new Osu(osuIndex);
                    osu.GetSongId();
                    osu.SongDownload();

                    Process p = Process.Start("osu!.exe", "osu.osz");

                    Console.WriteLine("{0}finish!", arg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Thread.Sleep(10000);
            }
        }
    }
}
