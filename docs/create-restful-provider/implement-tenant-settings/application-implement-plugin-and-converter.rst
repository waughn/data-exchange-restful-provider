Implement Application 
=======================================

Follow these step to create the *plugin*, *item model* and *converter* for a resource.

1. In Visual Studio, add the following class:

   .. code-block:: c#

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

   .. tip::
       When a `pipeline batch <http://integrationsdn.sitecore.net/DataExchangeFramework/v1.4.1/getting-started/process-modeling/pipeline-batch.html>`_ is run, 
       `converters <http://integrationsdn.sitecore.net/DataExchangeFramework/v1.4.1/getting-started/configuration/converter.html>`_ are instantiated **once** for 
       `plugins <http://integrationsdn.sitecore.net/DataExchangeFramework/v1.4.1/getting-started/configuration/plugin.html>`_. If settings are 
       updated during the process, use a `Func<TResult> Delegate <https://docs.microsoft.com/en-us/dotnet/api/system.func-1?view=netframework-4.5.1>`_ 
       to get updated values.

       
2. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
       {
           public class ApplicationItemModel : ItemModel
           {
               public const string BaseUrl = Templates.Application.FieldNames.BaseUrl;
       
               public const string RefreshToken = Templates.Application.FieldNames.RefreshToken;
               public const string AccessToken = Templates.Application.FieldNames.AccessToken;
               public const string AccessTokenDate = Templates.Application.FieldNames.AccessTokenDate;
               public const string ExpiresIn = Templates.Application.FieldNames.ExpiresIn;
       
               public const string AuthenticationResource = Templates.Application.FieldNames.AuthenticationResource;
           }
       }

3. Add the following class:

   .. code-block:: c#
   
        using System;
        using Sitecore.DataExchange;
        using Sitecore.DataExchange.Converters;
        using Sitecore.DataExchange.Extensions;
        using Sitecore.DataExchange.Repositories;
        using Sitecore.Services.Core.Model;
        using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
        using DataExchange.Providers.RESTful.Plugins.Settings;
        
        namespace DataExchange.Providers.RESTful.Converters.Settings
        {
            public class ApplicationConverter : BaseItemModelConverter<ApplicationSettings>
            {
                public ApplicationConverter(IItemModelRepository repository) : base(repository)
                {
                    this.SupportedTemplateIds.Add(Templates.Application.TemplateId);
                }
        
                protected override ConvertResult<ApplicationSettings> ConvertSupportedItem(ItemModel source)
                {
                    return this.PositiveResult(this.ConvertApplicationSettings(source));
                }
        
                protected ApplicationSettings RefreshPlugin(Guid itemId)
                {
                    ApplicationSettings applicationSettings = null;
        
                    if (this.ItemModelRepository != null)
                    {
                        var source = this.ItemModelRepository.Get(itemId);
                        applicationSettings = this.ConvertApplicationSettings(source);
                    }
        
                    return applicationSettings;
                }
        
                protected ApplicationSettings ConvertApplicationSettings(ItemModel source)
                {
                    var applicationSettings = new ApplicationSettings
                    {
                        ItemId = source.GetItemId(), 
                        BaseUrl = base.GetStringValue(source, ApplicationItemModel.BaseUrl),
                        RefreshToken = base.GetStringValue(source, ApplicationItemModel.RefreshToken),
                        AccessToken = base.GetStringValue(source, ApplicationItemModel.AccessToken),
                        AccessTokenDate = base.GetDateTimeValue(source, ApplicationItemModel.AccessTokenDate),
                        ExpiresIn = base.GetIntValue(source, ApplicationItemModel.ExpiresIn),
                        RefreshPlugin = () => this.RefreshPlugin(source.GetItemId())
                    };
        
                    var resource = this.ConvertReferenceToModel<ResourceSettings>(source, ApplicationItemModel.AuthenticationResource);
                    if (resource != null)
                        applicationSettings.AuthenticationResource = resource;
        
                    if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                        Context.Logger.Warn("No Base Url was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.BaseUrl);
        
                    if (string.IsNullOrWhiteSpace(applicationSettings.RefreshToken))
                        Context.Logger.Warn("No refresh token was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.RefreshToken);
        
                    if (applicationSettings.AuthenticationResource == null)
                        Context.Logger.Warn("No authentication resource was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.AuthenticationResource);
        
                    return applicationSettings;
                }
            }
        }

   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
       
           using System;
           using Sitecore.DataExchange;
           using Sitecore.DataExchange.Converters;
           using Sitecore.DataExchange.Extensions;
           using Sitecore.DataExchange.Repositories;
           using Sitecore.Services.Core.Model;
           using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
           using DataExchange.Providers.RESTful.Plugins.Settings;
           
           namespace DataExchange.Providers.RESTful.Converters.Settings
           {
               public class ApplicationConverter : BaseItemModelConverter<ApplicationSettings>
               {
                   public ApplicationConverter(IItemModelRepository repository) : base(repository)
                   {
                       this.SupportedTemplateIds.Add(Templates.Application.TemplateId);
                   }
           
                   public override ApplicationSettings Convert(ItemModel source)
                   {
                       return this.ConvertApplicationSettings(source);
                   }
           
                   protected ApplicationSettings RefreshPlugin(Guid itemId)
                   {
                       ApplicationSettings applicationSettings = null;
           
                       if (this.ItemModelRepository != null)
                       {
                           var source = this.ItemModelRepository.Get(itemId);
                           applicationSettings = this.ConvertApplicationSettings(source);
                       }
           
                       return applicationSettings;
                   }
           
                   protected ApplicationSettings ConvertApplicationSettings(ItemModel source)
                   {
                       var applicationSettings = new ApplicationSettings
                       {
                           ItemId = source.GetItemId(), 
                           BaseUrl = base.GetStringValue(source, ApplicationItemModel.BaseUrl),
                           RefreshToken = base.GetStringValue(source, ApplicationItemModel.RefreshToken),
                           AccessToken = base.GetStringValue(source, ApplicationItemModel.AccessToken),
                           AccessTokenDate = base.GetDateTimeValue(source, ApplicationItemModel.AccessTokenDate),
                           ExpiresIn = base.GetIntValue(source, ApplicationItemModel.ExpiresIn),
                           RefreshPlugin = () => this.RefreshPlugin(source.GetItemId())
                       };
           
                       var resource = this.ConvertReferenceToModel<ResourceSettings>(source, ApplicationItemModel.AuthenticationResource);
                       if (resource != null)
                           applicationSettings.AuthenticationResource = resource;
           
                       if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                           Context.Logger.Warn("No Base Url was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.BaseUrl);
           
                       if (string.IsNullOrWhiteSpace(applicationSettings.RefreshToken))
                           Context.Logger.Warn("No refresh token was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.RefreshToken);
           
                       if (applicationSettings.AuthenticationResource == null)
                           Context.Logger.Warn("No authentication resource was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.AuthenticationResource);
           
                       return applicationSettings;
                   }
               }
           }

		   
   .. tip::

       Use the ``ItemModelRepository`` property from the base class for converters (``Sitecore.DataExchange.Converters.BaseItemModelConverter<TTo>``) 
       to retrieve item values using item identifier.

   .. important:: 

       See Tip and Note from :doc:`index` for more information about ``templates.cs``.

