using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class HomeWork4
    {
        public static async Task Main(string[] args)
        {
            string[] urls = {
                "https://www.dwsamplefiles.com/?dl_id=173",
                "https://www.dwsamplefiles.com/?dl_id=174",
                "https://www.dwsamplefiles.com/?dl_id=175",
                "https://www.dwsamplefiles.com/?dl_id=176",
                "https://www.dwsamplefiles.com/?dl_id=177",
                "https://www.dwsamplefiles.com/?dl_id=178",
                "https://www.dwsamplefiles.com/?dl_id=179",
                "https://www.dwsamplefiles.com/?dl_id=180",
            };

            Console.WriteLine("Downloading files asynchronously...");
            DateTime startTime = DateTime.Now;
            await DownloadFilesAsync(urls);
            DateTime endTime = DateTime.Now;

            Console.WriteLine($"Total time taken: {(endTime - startTime).TotalMilliseconds} milliseconds");
            Console.WriteLine("Press any key to exit.");
            // Console.ReadKey();
        }

        static async Task DownloadFilesAsync(string[] urls)
        {
            List<Task> tasks = new List<Task>();

            foreach (var url in urls)
            {
                tasks.Add(DownloadFileAsync(url));
            }

            await Task.WhenAll(tasks);
        }

        static async Task DownloadFileAsync(string url)
{
    using (HttpClient client = new HttpClient())
    {
        string fileName = Path.GetFileName(url);
        fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine($"Invalid filename for URL: {url}");
            return;
        }
        
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        using (HttpResponseMessage response = await client.GetAsync(url))
        using (HttpContent content = response.Content)
        {
            byte[] data = await content.ReadAsByteArrayAsync();
            File.WriteAllBytes(filePath, data);
        }
        Console.WriteLine($"Downloaded {fileName} from {url}");
    }
}

    }
}
