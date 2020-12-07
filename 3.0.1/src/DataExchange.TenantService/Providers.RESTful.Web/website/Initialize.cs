using System;
using System.Web.Http;
using DataExchange.Providers.RESTful.Plugins.Context;
using DataExchange.Providers.RESTful.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Web.Configurations;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DataExchange.Providers.RESTful.Web.Initialize), "Register")]
namespace DataExchange.Providers.RESTful.Web
{
    public class Initialize
    {
        public static void Register()
        {
            try
            {
                var property = (IConfiguration)GlobalConfiguration.Configuration.Properties["SitecoreConfigurationRoot"];

                var serviceCollection = new ServiceCollection();
                serviceCollection.UseDataExchangeWebServiceIntializationConfiguration(property, "Sitecore:DataExchange:RESTful");

                var provider = serviceCollection.BuildServiceProvider();

                Context.Plugins.Add(new RepositorySettings
                {
                    Client = provider.GetService<IClientRepository>()
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during initialization");
            }
        }
    }
}
