Implement Endpoint 
=======================================

Follow these step to create the *plugin*, *item model*, *converter* and extension methods.

.. note::
    Settings for the **RESTful Endpoint** are primarily stored on the **Application** item in the *tenant settings*.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange;
       using DataExchange.Providers.RESTful.Plugins.Settings;
       
       namespace DataExchange.Providers.RESTful.Plugins.Endpoints
       {
           public class ApplicationEndpointSettings : IPlugin
           {
               public ApplicationSettings Application { get; set; }
           }
       }

2. Add the following class:

   .. code-block:: c#

       using DataExchange.Providers.RESTful.Plugins.Endpoints;
       
       namespace DataExchange.Providers.RESTful.Extensions
       {
           public static class EndpointExtensions
           {
               public static ApplicationEndpointSettings GetApplicationEndpointSettings(this Endpoint endpoint)
               {
                   return endpoint.GetPlugin<ApplicationEndpointSettings>();
               }
       
               public static bool HasApplicationEndpointSettings(this Endpoint endpoint)
               {
                   return GetApplicationEndpointSettings(endpoint) != null;
               }
           }
       }
       
3. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Endpoints
       {
           public class ApplicationEndpointItemModel : ItemModel
           {
               public const string Application = Templates.RESTfulEndpoint.FieldNames.Application;
           }
       }

4. Add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange;
       using Sitecore.DataExchange.Converters.Endpoints;
       using Sitecore.DataExchange.Extensions;
       using Sitecore.DataExchange.Models;
       using Sitecore.DataExchange.Repositories;
       using Sitecore.Services.Core.Model;
       using DataExchange.Providers.RESTful.Models.ItemModels.Endpoints;
       using DataExchange.Providers.RESTful.Plugins.Endpoints;
       using DataExchange.Providers.RESTful.Plugins.Settings;
       
       namespace DataExchange.Providers.RESTful.Converters.Endpoints
       {
           public class ApplicationEndpointConverter : BaseEndpointConverter
           {
               public ApplicationEndpointConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.RESTfulEndpoint.TemplateId);
               }
       
               protected override void AddPlugins(ItemModel source, Endpoint endpoint)
               {
                   var applicationEndpointSettings = new ApplicationEndpointSettings();
                   var model = this.ConvertReferenceToModel<ApplicationSettings>(source, ApplicationEndpointItemModel.Application);
                   if (model != null)
                       applicationEndpointSettings.Application = model;
       
                   if (applicationEndpointSettings.Application == null)
                       Context.Logger.Error("No application was specified for the endpoint. (item: {0}, field: {1})", source.GetItemId(), Templates.RESTfulEndpoint.FieldNames.Application);
       
                   endpoint.Plugins.Add(applicationEndpointSettings);
               }
           }
       }
       
   .. important:: 

       See Tip and Note from :doc:`../implement-tenant-settings/index` for more information about ``templates.cs``.
