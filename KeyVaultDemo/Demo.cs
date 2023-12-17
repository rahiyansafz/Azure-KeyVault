using System.Collections.Generic;
using System.Net;
using B2C.Configurations;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace KeyVaultDemo
{
    public class Demo
    {
        private readonly ILogger _logger;
        private readonly IB2CUserServiceConfiguration _b2CUserServiceConfiguration;

        public Demo(
            ILoggerFactory loggerFactory,
            IB2CUserServiceConfiguration b2CUserServiceConfiguration
        )
        {
            _logger = loggerFactory.CreateLogger<Demo>();
            _b2CUserServiceConfiguration = b2CUserServiceConfiguration;
        }

        [Function("Demo")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "keyvault/demo")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(
                $"TenantId: {_b2CUserServiceConfiguration.TenantId}" +
                $"\nAppId: {_b2CUserServiceConfiguration.AppId}");

            return response;
        }
    }
}
