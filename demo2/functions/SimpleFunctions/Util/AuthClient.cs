using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using SimpleFunctions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFunctions.Util
{
    public class AuthClient : IAuthClient
    {
        private readonly IConfidentialClientApplication _authClient;

        public AuthClient(
            IOptions<Settings> options
        )
        {
            _authClient = ConfidentialClientApplicationBuilder.Create(options.Value.ClientId)
                .WithAuthority($"https://login.microsoftonline.com/{options.Value.TenantId}/v2.0")
                .WithClientSecret(options.Value.Secret)
                .Build();
        }

        public async Task<string> AqureToken(IEnumerable<string> scopes)
        {
            var res = await _authClient.AcquireTokenForClient(scopes).ExecuteAsync();
            return res.AccessToken;
        }
    }
}
