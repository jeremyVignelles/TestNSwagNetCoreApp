using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore.Builder;
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
                    services.AddOpenApiDocument(configure =>
                        {
                            configure.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                            configure.GenerateKnownTypes = true;
                        });
                    services.AddMvc()
                        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                })
                .Configure(app =>
                {
                    app.UseSwagger()
                        .UseSwaggerUi3();
                    app.UseMvc();
                });
    }
}
