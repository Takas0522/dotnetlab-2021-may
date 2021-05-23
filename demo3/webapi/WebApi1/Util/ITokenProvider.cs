using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi1.Util
{
    public interface ITokenProvider
    {
        Task<string> GetTokenOnBeHalfOfFlowAsync(IEnumerable<string> scopes);
    }
}