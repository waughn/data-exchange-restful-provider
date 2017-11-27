Implement Repository Settings 
=======================================

Follow these step to create a *plugin* for repository settings.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using DataExchange.Providers.RESTful.Repositories;
       using Sitecore.DataExchange;
       
       namespace DataExchange.Providers.RESTful.Plugins.Context
       {
           public class RepositorySettings : IPlugin
           {
               public IClientRepository Client { get; set; }
           }
       }

.. note::
    No extension method was added for RepositorySettings plugin because it is access from 
    ``public static T GetPlugin<T>() where T : IPlugin`` in the **Sitecore.DataExchange.Context**.