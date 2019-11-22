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
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(configRoot);
            services.AddSingleton(configRoot.GetSection("AzureAd").Get<AzureAdApplicationSettings>());
            services.AddSingleton<GraphService>();

            var provider = services.BuildServiceProvider();
            var service = provider.GetService<GraphService>();
        }

    }

}
