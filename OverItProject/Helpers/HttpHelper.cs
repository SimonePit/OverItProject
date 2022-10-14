using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OverItProject.Helpers
{
    public class HttpHelper
    {
        public static async Task<T> HttpGetRequest<T>(string _url) where T : new()
        {
            T outputData = new T();
            using (var client = new HttpClient())
            {
                try
                {
                    client.Timeout = TimeSpan.FromSeconds(15);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var url = new Uri(_url);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var resString = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(resString);
                        outputData = JsonConvert.DeserializeObject<T>(resString);
                    }
                    //lancio eccezione generica
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return outputData;
        }
    }
}
