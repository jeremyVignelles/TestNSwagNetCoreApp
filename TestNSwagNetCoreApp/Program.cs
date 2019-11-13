namespace TestNSwagNetCoreApp
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using NJsonSchema;
    using NJsonSchema.Generation;
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
                            //configure.SchemaType = SchemaType.Swagger2; // Works if uncommented
                            configure.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                            configure.GenerateKnownTypes = true;
                        });
                    services.AddMvc(o =>
                        {
                            o.InputFormatters.Insert(0, new RawInputFormatter());
                        })
                        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                })
                .Configure(app =>
                {
                    app.UseOpenApi()
                        .UseSwaggerUi3();
                    app.UseMvc();
                });
    }
}
