using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFunctions.Util
{
    public class WebApiRequest : IWebApiRequest
    {
        private readonly HttpClient _client;
        public WebApiRequest(
            HttpClient client
        )
        {
            _client = client;
        }

        public async Task<string> GetRequestAsync(string url, string token)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.Add("Authorization", $"Bearer {token}");
            var response = await _client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var resSt = await response.Content.ReadAsStringAsync();
                return resSt;
            }
            return "";
        }
    }
}
