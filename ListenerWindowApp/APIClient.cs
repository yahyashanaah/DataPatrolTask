using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ListenerWindowApp
{
    public class APIClient
    {
        public List<Listener> Listeners = new List<Listener>();
        private CancellationTokenSource cts;  

        private bool running = false;

        public void Start()
        {
            running = true;
            cts = new CancellationTokenSource();
            Task.Run(() => PollAPI(cts.Token));
        }

        public void Stop()
        {
            running = false;
            cts?.Cancel();
        }

        private async Task PollAPI(CancellationToken token)
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        var response = await client.GetStringAsync("https://localhost:7240/random");
                        var result = JsonConvert.DeserializeObject<ApiResponse>(response);
                        int number = result.Data.Number;

                        foreach (var listener in Listeners)
                        {
                            listener.Process(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error calling API: " + ex.Message);
                    }

                    await Task.Delay(10000, token);
                }
            }
        }

    }
}
