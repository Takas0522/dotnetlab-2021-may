using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOneWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DemoOneController : ControllerBase
    {

        private readonly ILogger<DemoOneController> _logger;

        public DemoOneController(ILogger<DemoOneController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RetrunData Get()
        {
            return new RetrunData
            {
                Name = "WebApiOne",
                Value = "Rerturn Value"
            };
        }
    }

    public class RetrunData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
