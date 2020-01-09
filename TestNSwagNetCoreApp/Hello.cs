using Microsoft.AspNetCore.Mvc;
using NSwag;

namespace TestNSwagNetCoreApp
{
    using System;
    using Newtonsoft.Json;
    using NJsonSchema.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(HelloController))]
    [ApiController]
    [Route("Hello")]
    public class HelloController : Controller
    {
        /// <summary>
        /// Returns a greeting message
        /// </summary>
        /// <returns>The greeting message</returns>
        [HttpGet("Index")]
        public string Index()
        {
            return "Hello";
        }

        /// <summary>
        /// Returns a greeting message, as a JSON object
        /// </summary>
        /// <returns>The greeting message</returns>
        [HttpGet("Model")]
        public HelloWorldModel Model()
        {
            return new HelloWorldModel();
        }

        /// <summary>
        /// Returns info about the API
        /// </summary>
        [HttpGet("Info")]
        public OpenApiInfo ApiInfo()
        {
            return new OpenApiInfo();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(ItemRequired = Required.Always)]
    public class HelloWorldModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Hello { get; set; } = "World";

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public string Extra { get; set; }

        /// <summary>
        /// The expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}