using System;
using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Settings
{
    public class ApplicationSettings : IPlugin
    {
        public Guid ItemId { get; set; } // used to resolve sitecore item 

        public string BaseUrl { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenDate { get; set; }
        public int ExpiresIn { get; set; }

        public ResourceSettings AuthenticationResource { get; set; }

        public Func<IPlugin> RefreshPlugin { get; set; }
    }
}
