using Newtonsoft.Json.Linq;
using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Processors
{
    public class ReadResourceDataSettings : IPlugin
    {
        public string PathExpression { get; set; }
    }
}