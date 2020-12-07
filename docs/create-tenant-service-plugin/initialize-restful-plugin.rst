Initialize RESTful Provider Plugins 
=======================================

Follow these step to initialize *plugins* for RESTful Provider for Data Exchange Framework.

.. important::
    `WebActivatorEx <https://www.nuget.org/packages/WebActivatorEx>`_ is used to execute the initialization code.

1. In Visual Studio, add the following class:

   .. code-block:: c#

      using System;
      using System.Web.Http;
      using DataExchange.Providers.RESTful.Plugins.Context;
      using DataExchange.Providers.RESTful.Repositories;
      using Microsoft.Extensions.Configuration;
      using Microsoft.Extensions.DependencyInjection;
      using Serilog;
      using Sitecore.DataExchange;
      using Sitecore.DataExchange.Web.Configurations;
      
      [assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DataExchange.Providers.RESTful.Web.Initialize), "Register")]
      namespace DataExchange.Providers.RESTful.Web
      {
          public class Initialize
          {
              public static void Register()
              {
                  try
                  {
                      var property = (IConfiguration)GlobalConfiguration.Configuration.Properties["SitecoreConfigurationRoot"];
      
                      var serviceCollection = new ServiceCollection();
                      serviceCollection.UseDataExchangeWebServiceIntializationConfiguration(property, "Sitecore:DataExchange:RESTful");
      
                      var provider = serviceCollection.BuildServiceProvider();
      
                      Context.Plugins.Add(new RepositorySettings
                      {
                          Client = provider.GetService<IClientRepository>()
                      });
                  }
                  catch (Exception ex)
                  {
                      Log.Error(ex, "Error during initialization");
                  }
              }
          }
      }

2. Add the following to **sc.RESTful.Service.xml** in **App_Data\\config\\sitecore\\RESTfulService** directory:

   .. code-block:: xml

       <Settings>
         <Sitecore>
           <DataExchange>
             <RESTful>
               <Service>
                 <Services>
                   <ClientRepository>
                     <Type>DataExchange.Providers.RESTful.Repositories.ClientRepository, DataExchange.Providers.RESTful</Type>
                     <As>DataExchange.Providers.RESTful.Repositories.IClientRepository, DataExchange.Providers.RESTful</As>
                     <LifeTime>Singleton</LifeTime>
                   </ClientRepository>
                 </Services>
               </Service>
             </RESTful>
           </DataExchange>
         </Sitecore>
       </Settings>

   .. note::
       Used to instantiate the Client in the RepositorySettings *plugin*.

3. Add the following to **sc.RESTful.Service.Initialize** in **App_Data\\config\\sitecore\\RESTfulService** directory:

   .. code-block:: xml

       <Settings>
         <Sitecore>
           <DataExchange>
             <RESTful>
               <Initialize>
                 <RESTfulProvider>Sitecore:DataExchange:RESTful:Service</RESTfulProvider>
               </Initialize>
             </RESTful>
           </DataExchange>
         </Sitecore>
       </Settings>       
