namespace TestNSwagNetCoreApp
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using NJsonSchema.Generation;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseKestrel()
                        .ConfigureServices(services =>
                        {
                            services.AddOpenApiDocument(configure =>
                            {
                                configure.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                                configure.GenerateKnownTypes = true;
                            });
                            services.AddMvc(o =>
                                {
                                    o.InputFormatters.Insert(0, new RawInputFormatter());
                                });
                        })
                        .Configure(app =>
                        {
                            app.UseRouting();
                            app.UseEndpoints(endpoints =>
                            {
                                endpoints.MapControllers();
                            });
                            app.UseOpenApi()
                                .UseSwaggerUi3();
                        });
                });
    }
}
