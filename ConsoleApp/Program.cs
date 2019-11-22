using ConsoleApp.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ConfigureServices();
            var config = provider.GetService<IConfiguration>();
            var aadSection = config.GetSection("AzureAd").Get<AzureAdOptions>();
        }



        static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            
            return services.BuildServiceProvider();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguration(builder =>
            {
                var dir = Directory.GetCurrentDirectory();

                builder
                    .SetBasePath(dir)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)

                    .Build()
                ;
            });
        }
    }

}
