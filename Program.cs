using System.Net.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Http_Man
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Welcome to HttpMan! (simple CLI http request creator)");
            while (true)
            {
                string method;
                while (true)
                {
                    Console.WriteLine("Request method (1 = Get | 2 = Post): ");
                    string userInput = Console.ReadLine();
                    if (userInput.Equals("1"))
                    {
                        method = "get";
                        break;
                    }
                    else if (userInput.Equals("2"))
                    {
                        method = "post";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                        continue;
                    }
                }

                Console.Write("Request url: ");
                string requestUrl = Console.ReadLine();

                if (method.Equals("get"))
                {
                    await GetRequest(requestUrl);
                }
                else if (method.Equals("post"))
                {
                    await PostRequest(requestUrl);
                }
            }
        }

        static async Task GetRequest(string url)
        {
            Console.WriteLine("Do you want to use any headers?: (yes = headers)");
            string userInput = Console.ReadLine();

            Dictionary<string, string>? headers = new();
            if (userInput.ToLower().Equals("yes"))
            {
                while (true)
                {
                    Console.Write("Header Key (stop = stop adding headers): ");
                    string headerKey = Console.ReadLine();
                    if (!headerKey.ToLower().Equals("stop"))
                    {
                        Console.Write("Header Value (stop = stop adding headers): ");
                        string headerValue = Console.ReadLine();
                        if (!headerValue.ToLower().Equals("stop"))
                        {
                            headers.Add(headerKey, headerValue);
                            Console.WriteLine();
                        }
                        else
                        {
                            if (headers.Count == 0)
                            {
                                headers = null;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (headers.Count == 0)
                        {
                            headers = null;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Making the request to: {url}");
            HttpResponseMessage response = await Requests.GetAsync(url, headers);
            Console.WriteLine($"Status code: {response.StatusCode} | {(int)response.StatusCode}");
            Console.WriteLine($"Content:\n{await response.Content.ReadAsStringAsync()}\n");
        }

        static async Task PostRequest(string url)
        {
            Console.WriteLine("Do you want to use any headers?: (yes = headers)");
            string userInput = Console.ReadLine();

            Dictionary<string, string>? headers = new();
            if (userInput.ToLower().Equals("yes"))
            {
                while (true)
                {
                    Console.Write("Header Key (stop = stop adding headers): ");
                    string headerKey = Console.ReadLine();
                    if (!headerKey.ToLower().Equals("stop"))
                    {
                        Console.Write("Header Value (stop = stop adding headers): ");
                        string headerValue = Console.ReadLine();
                        if (!headerValue.ToLower().Equals("stop"))
                        {
                            headers.Add(headerKey, headerValue);
                            Console.WriteLine();
                        }
                        else
                        {
                            if (headers.Count == 0)
                            {
                                headers = null;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (headers.Count == 0)
                        {
                            headers = null;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Do you want to use any body?: (yes = body)");
            userInput = Console.ReadLine();

            Dictionary<object, object>? body = new();
            if (userInput.ToLower().Equals("yes"))
            {
                while (true)
                {
                    Console.Write("Body Key (stop = stop adding body entries): ");
                    string bodyKey = Console.ReadLine();
                    if (!bodyKey.ToLower().Equals("stop"))
                    {
                        Console.Write("Body Value (stop = stop adding body entries): ");
                        string bodyValue = Console.ReadLine();
                        if (!bodyValue.ToLower().Equals("stop"))
                        {
                            body.Add(bodyKey, bodyValue);
                            Console.WriteLine();
                        }
                        else
                        {
                            if (body.Count == 0)
                            {
                                body = null;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (body.Count == 0)
                        {
                            body = null;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Making the request to: {url}");
            HttpResponseMessage response = await Requests.PostAsync(url, headers, body);
            Console.WriteLine($"Status code: {response.StatusCode} | {(int)response.StatusCode}");
            Console.WriteLine($"Content:\n{await response.Content.ReadAsStringAsync()}\n");
        }
    }
}
