using Sitecore.DataExchange.Models;
using DataExchange.Providers.RESTful.Plugins.Endpoints;

namespace DataExchange.Providers.RESTful.Extensions
{
    public static class EndpointExtensions
    {
        public static ApplicationEndpointSettings GetApplicationEndpointSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<ApplicationEndpointSettings>();
        }

        public static bool HasApplicationEndpointSettings(this Endpoint endpoint)
        {
            return GetApplicationEndpointSettings(endpoint) != null;
        }
    }
}
