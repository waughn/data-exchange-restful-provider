using System.Collections.Generic;
using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Settings
{
    public class ResourceSettings : IPlugin
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public IEnumerable<RequestHeaderSettings> Headers { get; set; }
        public IEnumerable<RequestParameterSettings> Parameters { get; set; }
        public PagingSettings Paging { get; set; }

    }
}