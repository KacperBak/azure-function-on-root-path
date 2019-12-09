using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RootMappedProject
{
    public static class MyRootMappedFunction
    {
        [FunctionName("Simple")]
        public static async Task<IActionResult> Simple(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing simple endpoint ...");
            return (ActionResult)new OkObjectResult("true");
        }

        [FunctionName("Root")]
        public static async Task<IActionResult> Root(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing root endpoint, this is a bad request");
            return (ActionResult) new BadRequestObjectResult("false");
        }
    }
}
