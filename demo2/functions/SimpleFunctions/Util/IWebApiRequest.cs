using System.Threading.Tasks;

namespace SimpleFunctions.Util
{
    public interface IWebApiRequest
    {
        Task<string> GetRequestAsync(string url, string token);
    }
}