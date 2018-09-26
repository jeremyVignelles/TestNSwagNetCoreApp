using Microsoft.AspNetCore.Mvc;

namespace TestNSwagNetCoreApp
{
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(HelloController))]
    [ApiController]
    [Route("Hello")]
    public class HelloController : Controller
    {
        // GET
        [HttpGet("Index")]
        public string Index()
        {
            return "Hello";
        }
    }
}