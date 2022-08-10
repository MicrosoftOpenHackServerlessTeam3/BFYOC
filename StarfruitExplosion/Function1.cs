using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace StarfruitExplosion
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> log)
        {
            _logger = log;
        }

        [FunctionName("StarfruitExplosionTeam3")]
        [OpenApiOperation(operationId: "Get", tags: new[] { "GetProductId" })]
        [OpenApiParameter(name: "productId", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The product id")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public IActionResult Get( [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/v1/starfruit")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var productId = req.Query["productId"];


            if (string.IsNullOrEmpty(productId)) return new BadRequestObjectResult("Product id is required");

            var response  = $"The product name for your product id {productId} is Starfruit Explosion";

            return new OkObjectResult(response);
        }
    }
}

