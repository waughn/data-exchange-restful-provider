using DataExchange.Providers.RESTful.Repositories;
using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Context
{
    public class RepositorySettings : IPlugin
    {
        public IClientRepository Client { get; set; }
    }
}
