using Microsoft.AspNetCore.Mvc;

namespace TestNSwagNetCoreApp
{
    using System;
    using NJsonSchema.Annotations;

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

        // GET
        [HttpGet("Model")]
        public HelloWorldModel Model()
        {
            return new HelloWorldModel();
        }
    }

    public class HelloWorldModel
    {
        public string Hello { get; set; } = "World";

        [CanBeNull]
        public string Extra { get; set; }

        /// <summary>
        /// The expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}