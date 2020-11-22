namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
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
        /// Returns a greeting message, as a JSON object
        /// </summary>
        /// <returns>The greeting message</returns>
        [ProducesResponseType(typeof(HelloWorldModel), 200)]
        [ProducesResponseType(typeof(void), 204)]
        [HttpGet("Model")]
        public HelloWorldModel? Model()
        {
            if (new Random().Next(100) > 50)
            {
                return new HelloWorldModel();
            }
            else
            {
                return null;
            }
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