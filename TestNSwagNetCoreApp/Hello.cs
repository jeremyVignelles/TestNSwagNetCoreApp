using System.IO;
using NJsonSchema.Annotations;

namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using NSwag.Annotations;
    using System;

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
        /// Echoes the message passed as input
        /// </summary>
        [HttpPost("Echo")]
        //[OpenApiBodyParameter("text/plain")] // Does not generate text/plain but application/json input with string type
        [TestOpenApiBodyParameter("text/plain")] // Works OK
        public string Echo([FromBody, JsonSchemaType(typeof(byte[]))] StringModel message)
        {
            return message.Content;
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
        public string? Extra { get; set; }

        /// <summary>
        /// The expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}