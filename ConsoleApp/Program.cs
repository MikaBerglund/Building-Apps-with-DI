using Abstracts.Configuration;
using CommonServices;
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
            var service = provider.GetService<GraphService>();
        }



        static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            return services.BuildServiceProvider();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)

                .Build()
            ;

            services.AddSingleton(configRoot);
            services.AddSingleton<IConfiguration>(configRoot);
            services.AddSingleton(configRoot.GetSection("AzureAd").Get<AzureAdApplicationSettings>());
            services.AddSingleton<GraphService>();
        }

    }

}
