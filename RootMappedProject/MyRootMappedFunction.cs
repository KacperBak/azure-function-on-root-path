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
        /// <summary>
        /// curl -v 127.0.0.1/Simple
        /// </summary>
        /// <returns>HTTP/1.1 200 OK</returns>
        [FunctionName("Simple")]
        public static async Task<IActionResult> Simple(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing simple endpoint ...");
            return (ActionResult)new OkObjectResult("true");
        }

        /// <summary>
        /// curl -v 127.0.0.1 should return 400 Status code
        /// </summary>
        /// <returns>HTTP/1.1 204 No Content</returns>
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
