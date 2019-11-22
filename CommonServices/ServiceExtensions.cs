using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {

        public static IConfigurationBuilder AddConfiguration(this IServiceCollection services)
        {

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services, Action<IConfigurationBuilder> builderAction)
        {
            var builder = new ConfigurationBuilder();
            builderAction(builder);
            var configRoot = builder.Build();

            services.AddSingleton<IConfigurationRoot>(configRoot);
            services.AddSingleton<IConfiguration>(configRoot);

            return services;
        }


        public static IServiceCollection AddJsonFileConfiguration(this IServiceCollection services)
        {
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfigurationRoot>(configRoot);
            services.AddSingleton<IConfiguration>(configRoot);

            return services;
        }

    }
}
