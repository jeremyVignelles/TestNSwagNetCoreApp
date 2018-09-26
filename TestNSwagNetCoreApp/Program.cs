namespace TestNSwagNetCoreApp
{
    using System.Reflection;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using NJsonSchema;
    using NSwag.AspNetCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureServices(services =>
                {
                    services.AddMvc()
                        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                })
                .Configure(app =>
                {
                    //* // Remove/Add one slash at the beginning of this line to switch between versions

                    // Works: provides a Form to upload in Swagger UI
                    app.UseSwaggerUi3(Assembly.GetExecutingAssembly(), swagger =>
                    {
                        swagger.GeneratorSettings.IsAspNetCore = true;
                        swagger.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                        swagger.GeneratorSettings.DefaultEnumHandling = EnumHandling.Integer;
                        swagger.GeneratorSettings.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                        swagger.GeneratorSettings.GenerateKnownTypes = true;
                        swagger.DocExpansion = "list";
                    });
                    /*/
                    // Doesn't work: expects a JSON to be given
                    app.UseSwaggerUi3WithApiExplorer(swagger =>
                    {
                        swagger.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                        swagger.GeneratorSettings.DefaultEnumHandling = EnumHandling.Integer;
                        swagger.GeneratorSettings.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                        swagger.GeneratorSettings.GenerateKnownTypes = true;
                        swagger.GeneratorSettings.SchemaType = SchemaType.OpenApi3;
                        swagger.DocExpansion = "list";
                    });
                    //*/

                    app.UseMvc();
                });
    }
}
