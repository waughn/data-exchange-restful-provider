using Sitecore.DataExchange;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Plugins.Endpoints
{
    public class ApplicationEndpointSettings : IPlugin
    {
        public ApplicationSettings Application { get; set; }
    }
}
