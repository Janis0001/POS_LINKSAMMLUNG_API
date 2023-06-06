namespace LinkSammlungWebApp.Data;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

    public class DataDownloader
    {
        private readonly string apiUrl;
        private readonly HttpClient httpClient;

        public DataDownloader(string apiUrl)
        {
            this.apiUrl = apiUrl;
            httpClient = new HttpClient();
        }

        public async Task DownloadData(string filePath)
        {
            try
            {
                string data = await httpClient.GetStringAsync(apiUrl);
                var jsonData = JsonSerializer.Deserialize<object>(data);

                if (jsonData != null)
                {
                    string jsonString = JsonSerializer.Serialize(jsonData);
                    await File.WriteAllTextAsync(filePath, jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while downloading data: {ex.Message}");
            }
        }
    }
