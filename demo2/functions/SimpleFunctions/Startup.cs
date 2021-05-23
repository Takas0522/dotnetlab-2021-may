using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleFunctions.Models;
using SimpleFunctions.Util;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(SimpleFunctions.Startup))]
namespace SimpleFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<Settings>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("AzureAd").Bind(settings);
            });
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IAuthClient, AuthClient>();
            builder.Services.AddSingleton<IWebApiRequest, WebApiRequest>();
        }
    }
}
