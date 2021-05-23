using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi1.Util
{
    public class WebApiAccess : IWebApiAccess
    {
        private readonly HttpClient _httpClient;
        public WebApiAccess(
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRequestAsync(string url, string token)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);
            req.Headers.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var resSt = await response.Content.ReadAsStringAsync();
                return resSt;
            }
            return "";
        }
    }
}
