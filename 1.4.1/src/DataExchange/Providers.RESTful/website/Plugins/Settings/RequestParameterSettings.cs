using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Settings
{
    public class RequestParameterSettings : IPlugin
    {
        public string ParameterToken { get; set; }
        public string ParameterValue { get; set; }
    }
}