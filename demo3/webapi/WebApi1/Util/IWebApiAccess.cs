using System.Threading.Tasks;

namespace WebApi1.Util
{
    public interface IWebApiAccess
    {
        Task<string> GetRequestAsync(string url, string token);
    }
}