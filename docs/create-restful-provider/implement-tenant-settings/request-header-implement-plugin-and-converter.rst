Implement Request Header 
=======================================

Follow these step to create the *plugin*, *item model* and *converter* for a request header.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange;
       
       namespace DataExchange.Providers.RESTful.Plugins.Settings
       {
           public class RequestHeaderSettings : IPlugin
           {
               public string HeaderName { get; set; }
               public string HeaderValue { get; set; }
           }
       }

2. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
       {
           public class RequestHeaderItemModel : ItemModel
           {
               public const string HeaderName = Templates.RequestHeader.FieldNames.HeaderName;
               public const string HeaderValue = Templates.RequestHeader.FieldNames.HeaderValue;
           }
       }

3. Add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange.Converters;
       using Sitecore.DataExchange.Repositories;
       using Sitecore.Services.Core.Model;
       using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
       using DataExchange.Providers.RESTful.Plugins.Settings;
       
       namespace DataExchange.Providers.RESTful.Converters.Settings
       {
           public class RequestHeaderConverter : BaseItemModelConverter<RequestHeaderSettings>
           {
               public RequestHeaderConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.RequestHeader.TemplateId);
               }
       
               public override RequestHeaderSettings Convert(ItemModel source)
               {
                   var requestHeaderSettings = new RequestHeaderSettings
                   {
                       HeaderName = base.GetStringValue(source, RequestHeaderItemModel.HeaderName),
                       HeaderValue = base.GetStringValue(source, RequestHeaderItemModel.HeaderValue)
                   };
       
                   return requestHeaderSettings;
               }
           }
       }

   .. important:: 
       **v2.0**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
     
            using Sitecore.DataExchange.Converters;
            using Sitecore.DataExchange.Repositories;
            using Sitecore.DataExchange;
            using Sitecore.Services.Core.Model;
            using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
            using DataExchange.Providers.RESTful.Plugins.Settings;
            
            namespace DataExchange.Providers.RESTful.Converters.Settings
            {
                public class RequestHeaderConverter : BaseItemModelConverter<RequestHeaderSettings>
                {
                    public RequestHeaderConverter(IItemModelRepository repository) : base(repository)
                    {
                        this.SupportedTemplateIds.Add(Templates.RequestHeader.TemplateId);
                    }
            
                    protected override ConvertResult<RequestHeaderSettings> ConvertSupportedItem(ItemModel source)
                    {
                        var requestHeaderSettings = new RequestHeaderSettings
                        {
                            HeaderName = base.GetStringValue(source, RequestHeaderItemModel.HeaderName),
                            HeaderValue = base.GetStringValue(source, RequestHeaderItemModel.HeaderValue)
                        };
            
                        return this.PositiveResult(requestHeaderSettings);
                    }
                }
            }   
	   
   .. important:: 

       See Tip and Note from :doc:`index` for more information about ``templates.cs``.
