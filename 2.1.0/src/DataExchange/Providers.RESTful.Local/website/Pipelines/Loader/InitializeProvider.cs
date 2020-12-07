using Sitecore.Configuration;
using Sitecore.DataExchange;
using Sitecore.Pipelines;
using DataExchange.Providers.RESTful.Plugins.Context;
using DataExchange.Providers.RESTful.Repositories;

namespace DataExchange.Providers.RESTful.Local.Pipelines.Loader
{
   public class InitializeProvider
    {
        public void Process(PipelineArgs args)
        {
            Context.Plugins.Add((IPlugin) new RepositorySettings
            {
                Client = Factory.CreateObject("dataExchange/providers/restful/clientRepository", true) as IClientRepository 
            });
        }
    }
}
