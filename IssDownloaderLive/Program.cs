﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

namespace IssDownloader
{
    public class Urls
    {
        [JsonProperty("360p")]
        public string Url360p { get; set; }
        [JsonProperty("144p")]
        public string Url440p { get; set; }
        [JsonProperty("480p")]
        public string Url480p { get; set; }
        [JsonProperty("240p")]
        public string Url240p { get; set; }
        [JsonProperty("730p")]
        public string Url730p { get; set; }
    }

    public class RootObject
    {
        public Urls urls { get; set; }
        public bool success { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // NASA TV:

            // http://nasatv-lh.akamaihd.net/i/NASA_101@319270/master.m3u8

            // Iss LIVE HD

            // http://iphone-streaming.ustream.tv/uhls/17074538/streams/live/iphone/playlist.m3u8

            ////var videoId = "ddFvjfvPnqk";
            //var videoId = "qzMQza8xZCc";

            //string html = string.Empty;
            //string url = @"http://pwn.sh/tools/streamapi.py?url=https://www.youtube.com/watch?v=";

            //var fullVideoPath = url + videoId;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullVideoPath);

            //request.KeepAlive = true;
            //request.Accept = "application/json, text/javascript, */*; q=0.01";
            //request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            //request.Referer = "http://pwn.sh/tools/getstream.html";
            //request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch");
            //request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,ro;q=0.6");

            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    html = reader.ReadToEnd();
            //}

            //RootObject deserializedJson = JsonConvert.DeserializeObject<RootObject>(html);

            //Console.WriteLine(deserializedJson.urls.Url440p);
            //Console.WriteLine(deserializedJson.urls.Url240p);
            //Console.WriteLine(deserializedJson.urls.Url360p);
            //Console.WriteLine(deserializedJson.urls.Url480p);
            //Console.WriteLine(deserializedJson.urls.Url730p);




            //var procGetFirst20Seconds = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = "ffmpeg.exe",
            //        Arguments = "-i " + m3U8UrlToDownload + " -c copy -t 00:00:20 output.mp4",
            //        UseShellExecute = false,
            //        RedirectStandardOutput = true,
            //        CreateNoWindow = true
            //    }
            //};

            //procGetFirst20Seconds.Start();
            ////while (!procGetFirst20Seconds.StandardOutput.EndOfStream)
            ////{
            ////    m3U8UrlToDownload = procGetFirst20Seconds.StandardOutput.ReadLine();
            ////}
            //procGetFirst20Seconds.WaitForExit();
            //var exitCodeGetFirst20Seconds = procGetFirst20Seconds.ExitCode;
            //procGetFirst20Seconds.Close();
            //Console.WriteLine("All Done");


            //get image


            var procGetFirst20Seconds = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //ffmpeg.exe -i http://iphone-streaming.ustream.tv/uhls/17074538/streams/live/iphone/playlist.m3u8 -s 480x300 -vf fps=1/10 -y -q:v 1 -update 1 photo.jpg

                    FileName = "ffmpeg.exe",
                    //Arguments = "-ss 0.5 -i " + "http://iphone-streaming.ustream.tv/uhls/17074538/streams/live/iphone/playlist.m3u8" + " -vframes 1 -s 480x300 -f image2 -y imagefile.jpg",
                    //Arguments = " -i " + "http://iphone-streaming.ustream.tv/uhls/17074538/streams/live/iphone/playlist.m3u8" + " -s 480x300 -vf fps=1/10 -y -q:v 1 -update 1 photo.jpg",
                    Arguments = "-ss 0 -i " + "http://iphone-streaming.ustream.tv/uhls/17074538/streams/live/iphone/playlist.m3u8" + " - t 60 -y out.mov",

                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            //procGetFirst20Seconds.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            //procGetFirst20Seconds.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

            //procGetFirst20Seconds.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            //procGetFirst20Seconds.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);

            procGetFirst20Seconds.Start();
            Console.WriteLine(procGetFirst20Seconds.StandardOutput);

            procGetFirst20Seconds.WaitForExit();
            var exitCodeGetFirst20Seconds = procGetFirst20Seconds.ExitCode;
            procGetFirst20Seconds.Close();
            Console.WriteLine("All Done");

            Console.ReadKey();
        }
        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //* Do your stuff with the output (write to console/log/StringBuilder)
            Console.WriteLine(outLine.Data);
        }
    }
}