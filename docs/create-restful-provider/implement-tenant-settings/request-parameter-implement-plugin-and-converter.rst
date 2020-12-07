Implement Request Parameter 
=======================================

Follow these step to create the *plugin*, *item model* and *converter* for a request parameter.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange;
       
       namespace DataExchange.Providers.RESTful.Plugins.Settings
       {
           public class RequestParameterSettings : IPlugin
           {
               public string ParameterToken { get; set; }
               public string ParameterValue { get; set; }
           }
       }

2. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
       {
           public class RequestParameterItemModel : ItemModel
           {
               public const string ParameterToken = Templates.RequestParameter.FieldNames.ParameterToken;
               public const string ParameterValue = Templates.RequestParameter.FieldNames.ParameterValue;
           }
       }

3. Add the following class:

   .. code-block:: c#
   
        using Sitecore.DataExchange.Converters;
        using Sitecore.DataExchange;
        using Sitecore.DataExchange.Repositories;
        using Sitecore.Services.Core.Model;
        using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
        using DataExchange.Providers.RESTful.Plugins.Settings;
        
        namespace DataExchange.Providers.RESTful.Converters.Settings
        {
            public class RequestParameterConverter : BaseItemModelConverter<RequestParameterSettings>
            {
                public RequestParameterConverter(IItemModelRepository repository) : base(repository)
                {
                    this.SupportedTemplateIds.Add(Templates.RequestParameter.TemplateId);
                }
        
                protected override ConvertResult<RequestParameterSettings> ConvertSupportedItem(ItemModel source)
                {
                    var requestParameterSettings = new RequestParameterSettings
                    {
                        ParameterToken = base.GetStringValue(source, RequestParameterItemModel.ParameterToken),
                        ParameterValue = base.GetStringValue(source, RequestParameterItemModel.ParameterValue)
                    };
        
                    return this.PositiveResult(requestParameterSettings);
                }
            }
        }

   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
       
           using Sitecore.DataExchange.Converters;
           using Sitecore.DataExchange.Repositories;
           using Sitecore.Services.Core.Model;
           using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
           using DataExchange.Providers.RESTful.Plugins.Settings;
           
           namespace DataExchange.Providers.RESTful.Converters.Settings
           {
               public class RequestParameterConverter : BaseItemModelConverter<RequestParameterSettings>
               {
                   public RequestParameterConverter(IItemModelRepository repository) : base(repository)
                   {
                       this.SupportedTemplateIds.Add(Templates.RequestParameter.TemplateId);
                   }
           
                   public override RequestParameterSettings Convert(ItemModel source)
                   {
                       var requestParameterSettings = new RequestParameterSettings
                       {
                           ParameterToken = base.GetStringValue(source, RequestParameterItemModel.ParameterToken),
                           ParameterValue = base.GetStringValue(source, RequestParameterItemModel.ParameterValue)
                       };
           
                       return requestParameterSettings;
                   }
               }
           }
			
   .. important:: 

       See Tip and Note from :doc:`index` for more information about ``templates.cs``.
