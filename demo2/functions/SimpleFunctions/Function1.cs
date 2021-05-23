using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SimpleFunctions.Models;
using SimpleFunctions.Util;

namespace SimpleFunctions
{
    public class Function1
    {
        private readonly IAuthClient _auth;
        private readonly IWebApiRequest _apiReq;
        public Function1(
            IAuthClient auth,
            IWebApiRequest apiReq
        )
        {
            _auth = auth;
            _apiReq = apiReq;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var res= await _auth.AqureToken(new List<string> { "https://graph.microsoft.com/.default" });
            var graphResult = await _apiReq.GetRequestAsync(@"https://graph.microsoft.com/v1.0/users/<UserId>", res);
            log.LogInformation(graphResult);

            var apiToken = await _auth.AqureToken(new List<string> { "<Scope>" });
            var apiResult = await _apiReq.GetRequestAsync(@"https://localhost:44338/demoone", apiToken);
            log.LogInformation(apiResult);

            string responseMessage = "Exit";

            return new OkObjectResult(responseMessage);
        }
    }
}

