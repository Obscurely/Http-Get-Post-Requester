using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Http_Man
{
    public class Requests
    {
#nullable enable
        public static async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? headers = null)
        {
            HttpResponseMessage response;
            using (HttpClient client = new())
            {
                if (headers != null)
                {
                    for (int i = 0; i < headers.Count; i++)
                    {
                        client.DefaultRequestHeaders.Add(headers.Keys.ElementAt(i), headers.Values.ElementAt(i));
                    }
                }
                response = await client.GetAsync(url);
            }

            return response;
        }
#nullable disable

#nullable enable
        public static async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string>? headers = null, Dictionary<object, object>? body = null)
        {
            HttpResponseMessage response;
            StringContent requestBody = new(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, "application/json");
            using (HttpClient client = new())
            {
                if (headers != null)
                {
                    for (int i = 0; i < headers.Count; i++)
                    {
                        client.DefaultRequestHeaders.Add(headers.Keys.ElementAt(i), headers.Values.ElementAt(i));
                    }
                }
                response = await client.PostAsync(url, requestBody);
            }

            return response;
        }
#nullable disable

#nullable enable
        public static async Task<string> GetAndReadAsync(string url, Dictionary<string, string>? headers = null)
        {
            HttpResponseMessage response;
            using (HttpClient client = new())
            {
                if (headers != null)
                {
                    for (int i = 0; i < headers.Count; i++)
                    {
                        client.DefaultRequestHeaders.Add(headers.Keys.ElementAt(i), headers.Values.ElementAt(i));
                    }
                }
                response = await client.GetAsync(url);
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
#nullable disable

#nullable enable
        public static async Task<string> PostAndReadAsync(string url, Dictionary<string, string>? headers = null, Dictionary<object, object>? body = null)
        {
            HttpResponseMessage response;
            StringContent requestBody = new(JsonConvert.SerializeObject(body, Formatting.Indented), Encoding.UTF8, "application/json");
            using (HttpClient client = new())
            {
                if (headers != null)
                {
                    for (int i = 0; i < headers.Count; i++)
                    {
                        client.DefaultRequestHeaders.Add(headers.Keys.ElementAt(i), headers.Values.ElementAt(i));
                    }
                }
                response = await client.PostAsync(url, requestBody);
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
#nullable disable
    }
}