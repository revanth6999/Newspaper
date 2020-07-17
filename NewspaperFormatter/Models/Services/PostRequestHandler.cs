using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewspaperFormatter.Models.Services
{
    public class PostRequestHandler
    {
        private HttpClientHandler _clientHandler;
        public PostRequestHandler()
        {
            _clientHandler = new HttpClientHandler();
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public async Task<HttpResponseMessage> send(String url, String content)
        {
            using (HttpClient client = new HttpClient(_clientHandler))
            {
                return await client.PostAsync(url, new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("newspaper", content)
                    })
                );
            }
        }
    }
}
