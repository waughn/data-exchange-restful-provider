Initialize Repository Settings
=======================================

Follow these step to create the *plugin*, *item model*, *converter* and extension methods.

1. In Visual Studio (DataExchange.Providers.RESTful.Local project), add the following class:

   .. tip::
       The Data Exchange Framework uses the Sitecore configuration factory to instantiate the Logger, ItemModelRepository and TenantRepository properties 
       for the ``Sitecore.DataExchange.Context``. Use the Sitecore configuration factory for basic dependency injection
       for context *plugins*.

   .. code-block:: c#

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

2. Add the following to a config file (e.g. DataExchange.Providers.RESTful.Local.config):

   .. code-block:: xml

       <configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
         <sitecore>
           <pipelines>
             <initialize>
               <processor type="DataExchange.Providers.RESTful.Local.Pipelines.Loader.InitializeProvider, DataExchange.Providers.RESTful.Local" />
             </initialize>
           </pipelines>
           <dataExchange>
             <providers>
               <restful>
                 <clientRepository type="DataExchange.Providers.RESTful.Repositories.ClientRepository, DataExchange.Providers.RESTful" />
               </restful>
             </providers>
           </dataExchange>
         </sitecore>
       </configuration>
       
.. note::
    If the RESTful provider is used in a remote client, the RepositorySettings *plugin* needs to be instantiated 
    similar to the ``Sitecore.DataExchange.Context.ItemModelRepository``.

