﻿using System;
using System.Linq;
using System.Net;

namespace SiteMapConsole
{
    public static class FileDownloader
    {
        public static string DownloadedFile(string fileUrl)
        {
            var filename = fileUrl.Split('/').Last();
            using (var client = new WebClient())
            {
                client.DownloadFile(fileUrl, filename);
            }
            Console.WriteLine("Parsing {0}",filename);
            return filename;
        }
    }
}