using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    /// <summary>
    ///  Using a base controller, the generated code is in Solution Items/ClientApiDefault.cs
    /// Should [ProducesResponseType(StatusCodes.Status204NoContent)] be defined here
    /// in order to get the 204 without exception when the returned object is null?
    /// </summary>
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {

    }
    
    /// <summary>
    /// 
    /// </summary>
    public class HelloController : BaseController
    {
        /// <summary>
        /// Here it is not generating 204 but on v13.6.2 it was
        /// </summary>
        [HttpGet]
        public Task<HelloWorldModel> Model() => Task.FromResult(new HelloWorldModel());

        /// <summary>
        /// If I define [ProducesResponseType(StatusCodes.Status204NoContent)]  here,
        /// the generated method doesn't return
        /// the Task[HelloWorldModel] but Task....
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<HelloWorldModel> NullableModel() => Task.FromResult(default(HelloWorldModel));
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