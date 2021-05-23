using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Util
{
    public class TokenProvider : ITokenProvider
    {
        private readonly ITokenAcquisition _tokenAcquisition;
        public TokenProvider(
            ITokenAcquisition tokenAcquisition
        )
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<string> GetTokenOnBeHalfOfFlowAsync(IEnumerable<string> scopes)
        {
            try
            {
                var token = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
                return token;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
