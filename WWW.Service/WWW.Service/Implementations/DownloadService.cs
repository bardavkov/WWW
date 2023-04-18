﻿using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WWW.Service.Interfaces
{
    public class DownloadService
    {
        ILogger<DownloadService> _logger;   
        public DownloadService(ILogger<DownloadService> logger) { 
            _logger = logger;
        }
        public void DownloadPngUrlToMedia(string url)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Media", "png", $"{DateTime.Today.ToString("dd.MM.yyyy")}", "test.jpg");

            Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            var a = Path.GetDirectoryName(fileName);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            };

            _logger.LogInformation($"Pictre was saved in : {fileName}");

        }
        public async Task<byte[]> DownloadJpgToByteArrowAsync(string url) { 
            using(WebClient client = new WebClient())
            {
                return await client.DownloadDataTaskAsync(url);
            };
        }
    }
}
