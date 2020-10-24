namespace TestNSwagNetCoreApp
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using NJsonSchema.Generation;

    /// <summary>
    /// The main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <param name="args">The application arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The method that creates the builder
        /// </summary>
        /// <param name="args">The program arguments</param>
        /// <returns>The host builder</returns>
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
                            services.AddMvc();
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
