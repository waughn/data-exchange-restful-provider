Implement Resource 
=======================================

Follow these step to create the *plugin*, *item model* and *converter* for a resource.

1. In Visual Studio, add the following class:

   .. code-block:: c#

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

2. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
       {
           public class ResourceItemModel : ItemModel
           {
               public const string ResourceUrl = Templates.Resource.FieldNames.Url;
               public const string Method = Templates.Resource.FieldNames.Method;
               public const string Headers = Templates.Resource.FieldNames.Headers;
               public const string Parameters = Templates.Resource.FieldNames.Parameters;
               public const string Paging = Templates.Resource.FieldNames.Paging;
           }
       }

   .. note::

       **ResourceUrl** is used instead of **Url** because ``public const string Url = "ItemUrl"`` already 
       exists in ``Sitecore.Services.Core.Model.ItemModel``.

3. Add the following class:

   .. code-block:: c#

       using System.Collections.Generic;
       using Sitecore.DataExchange;
       using Sitecore.DataExchange.Converters;
       using Sitecore.DataExchange.Extensions;
       using Sitecore.DataExchange.Repositories;
       using Sitecore.Services.Core.Model;
       using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
       using DataExchange.Providers.RESTful.Plugins.Settings;
       
       namespace DataExchange.Providers.RESTful.Converters.Settings
       {
           public class ResourceConverter : BaseItemModelConverter<ResourceSettings>
           {
               public ResourceConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.Resource.TemplateId);
               }
       
               public override ResourceSettings Convert(ItemModel source)
               {
                   var resourceSettings = new ResourceSettings
                   {
                       Url = base.GetStringValue(source, ResourceItemModel.ResourceUrl),
                       Method = base.GetStringValue(source, ResourceItemModel.Method),
                       Headers = base.ConvertReferencesToModels<RequestHeaderSettings>(source, ResourceItemModel.Headers) ?? new List<RequestHeaderSettings>(),
                       Parameters = base.ConvertReferencesToModels<RequestParameterSettings>(source, ResourceItemModel.Parameters) ?? new List<RequestParameterSettings>(),
                       Paging = base.ConvertReferenceToModel<PagingSettings>(source, ResourceItemModel.Paging)
                   };
       
                   if (resourceSettings.Url == null)
                       Context.Logger.Error("No Url was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Url);
       
                   if (resourceSettings.Method == null)
                       Context.Logger.Error("No method was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Method);
       
                   return resourceSettings;
               }
           }
       }

   .. important:: 
       **v2.0**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
     
            using System.Collections.Generic;
            using Sitecore.DataExchange;
            using Sitecore.DataExchange.Converters;
            using Sitecore.DataExchange.Extensions;
            using Sitecore.DataExchange.Repositories;
            using Sitecore.Services.Core.Model;
            using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
            using DataExchange.Providers.RESTful.Plugins.Settings;
            
            namespace DataExchange.Providers.RESTful.Converters.Settings
            {
                public class ResourceConverter : BaseItemModelConverter<ResourceSettings>
                {
                    public ResourceConverter(IItemModelRepository repository) : base(repository)
                    {
                        this.SupportedTemplateIds.Add(Templates.Resource.TemplateId);
                    }
            
                    protected override ConvertResult<ResourceSettings> ConvertSupportedItem(ItemModel source)
                    {
                        var resourceSettings = new ResourceSettings
                        {
                            Url = base.GetStringValue(source, ResourceItemModel.ResourceUrl),
                            Method = base.GetStringValue(source, ResourceItemModel.Method),
                            Headers = base.ConvertReferencesToModels<RequestHeaderSettings>(source, ResourceItemModel.Headers) ?? new List<RequestHeaderSettings>(),
                            Parameters = base.ConvertReferencesToModels<RequestParameterSettings>(source, ResourceItemModel.Parameters) ?? new List<RequestParameterSettings>(),
                            Paging = base.ConvertReferenceToModel<PagingSettings>(source, ResourceItemModel.Paging)
                        };
            
                        if (resourceSettings.Url == null)
                            Context.Logger.Error("No Url was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Url);
            
                        if (resourceSettings.Method == null)
                            Context.Logger.Error("No method was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Method);
            
                        return this.PositiveResult(resourceSettings);
                    }
                }
            }
       
   .. tip::

       Use the ``ConvertReferenceToModel<T>`` and ``ConvertReferencesToModels<T>`` methods from the base class for 
       converters (``Sitecore.DataExchange.Converters.BaseItemModelConverter<TTo>``) for **Link Types** to 
       convert reference values to item models.
       
   .. important:: 

       See Tip and Note from :doc:`index` for more information about ``templates.cs``.

