using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Util;

namespace WebApi1.Controllers
{
    public class ReturnDamaModel
    {
        public string GraphResult { get; set; }
        public string ApiResult { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class DemoThreeController : ControllerBase
    {

        private readonly ITokenProvider _tokenProvider;
        private readonly IWebApiAccess _webApiAccess;
        public DemoThreeController(
            ITokenProvider tokenProvider,
            IWebApiAccess webApiAccess
        )
        {
            _tokenProvider = tokenProvider;
            _webApiAccess = webApiAccess;
        }

        [HttpGet]
        public async Task<ReturnDamaModel> Get()
        {
            var resGraph = await _tokenProvider.GetTokenOnBeHalfOfFlowAsync(new List<string> { "https://graph.microsoft.com/user.read" });
            var graphResult = await _webApiAccess.GetRequestAsync(@"https://graph.microsoft.com/v1.0/me", resGraph);

            var apiToken = await _tokenProvider.GetTokenOnBeHalfOfFlowAsync(new List<string> { "api://e6563161-652c-493f-ab48-92617f2921dd/access" });
            var apiResult = await _webApiAccess.GetRequestAsync(@"https://localhost:44338/DemoOne", apiToken);

            var ret = new ReturnDamaModel {
            ApiResult = apiResult,
            GraphResult = graphResult
            };
            return ret;
        }
    }
}
