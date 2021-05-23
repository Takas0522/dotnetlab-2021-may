using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DemoOneConsole
{
    class Program
    {
        static IPublicClientApplication app;
        static void Main(string[] args)
        {
            app = PublicClientApplicationBuilder.Create("<ClientID>").WithAuthority(AzureCloudInstance.AzurePublic, "<TenantID>")
                .WithRedirectUri("http://localhost")
                .Build();

            // graphデータの取得
            var graphScopes = new List<string> { "<Scope>" };
            var tokenres = app.AcquireTokenInteractive(graphScopes).ExecuteAsync().Result;

            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://graph.microsoft.com/v1.0/me")
                };
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenres.AccessToken);
                var res = client.SendAsync(req).Result;
                var graphResult = res.Content.ReadAsStringAsync().Result;
                Console.WriteLine(graphResult);
            }

            // OriginalWebAPIデータの取得
            var myWpiScopes = new List<string> { "<Scope>" };
            var myApiTokenRes = app.AcquireTokenInteractive(myWpiScopes).ExecuteAsync().Result;

            using (HttpClient client = new HttpClient())
            {
                var req = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:44338/DemoOne")
                };
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", myApiTokenRes.AccessToken);
                var res = client.SendAsync(req).Result;
                var graphResult = res.Content.ReadAsStringAsync().Result;
                Console.WriteLine(graphResult);
            }
        }
    }
}
