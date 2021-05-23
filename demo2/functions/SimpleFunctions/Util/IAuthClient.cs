using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFunctions.Util
{
    public interface IAuthClient
    {
        Task<string> AqureToken(IEnumerable<string> scopes);
    }
}