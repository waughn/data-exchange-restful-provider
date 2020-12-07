using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Settings
{
    public class RequestHeaderSettings : IPlugin
    {
        public string HeaderName { get; set; }
        public string HeaderValue { get; set; }
    }
}