Implement Paging 
=======================================

Follow these step to create the *plugin*, *item model* and *converter* for a paging.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.DataExchange;
       
       namespace DataExchange.Providers.RESTful.Plugins.Settings
       {
           public class PagingSettings : IPlugin
           {
               public int FirstPageNumber { get; set; }
               public int PageSize { get; set; }
               public int MaximumCount { get; set; }
               public string CurrentPagePathExpression { get; set; }
               public string PageSizePathExpression { get; set; }
               public string TotalCountPathExpression { get; set; }
               public string NextTokenPathExpression { get; set; }
           }
       }

2. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
       {
           public class PagingItemModel : ItemModel
           {
               public const string FirstPageNumber = Templates.Paging.FieldNames.FirstPageNumber;
               public const string PageSize = Templates.Paging.FieldNames.PageSize;
               public const string MaximumCount = Templates.Paging.FieldNames.MaximumCount;
               public const string CurrentPagePathExpression = Templates.Paging.FieldNames.CurrentPagePathExpression;
               public const string PageSizePathExpression = Templates.Paging.FieldNames.PageSizePathExpression;
               public const string TotalCountPathExpression = Templates.Paging.FieldNames.TotalCountPathExpression;
               public const string NextTokenPathExpression = Templates.Paging.FieldNames.NextTokenPathExpression;
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
           public class PagingConverter : BaseItemModelConverter<PagingSettings>
           {
               public PagingConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.Paging.TemplateId);
               }
       
               public override PagingSettings Convert(ItemModel source)
               {
                   var pagingSettings = new PagingSettings
                   {
                       FirstPageNumber = base.GetIntValue(source, PagingItemModel.FirstPageNumber),
                       PageSize = base.GetIntValue(source, PagingItemModel.PageSize),
                       MaximumCount = base.GetIntValue(source, PagingItemModel.MaximumCount),
                       CurrentPagePathExpression = base.GetStringValue(source, PagingItemModel.CurrentPagePathExpression),
                       PageSizePathExpression = base.GetStringValue(source, PagingItemModel.PageSizePathExpression),
                       TotalCountPathExpression = base.GetStringValue(source, PagingItemModel.TotalCountPathExpression),
                       NextTokenPathExpression = base.GetStringValue(source, PagingItemModel.NextTokenPathExpression)
                   };
       
                   return pagingSettings;
               }
           }
       }

   .. important:: 
       **v2.0**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
     
            using Sitecore.DataExchange;
            using Sitecore.DataExchange.Converters;
            using Sitecore.DataExchange.Repositories;
            using Sitecore.Services.Core.Model;
            using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
            using DataExchange.Providers.RESTful.Plugins.Settings;
            
            namespace DataExchange.Providers.RESTful.Converters.Settings
            {
                public class PagingConverter : BaseItemModelConverter<PagingSettings>
                {
                    public PagingConverter(IItemModelRepository repository) : base(repository)
                    {
                        this.SupportedTemplateIds.Add(Templates.Paging.TemplateId);
                    }
            
                    protected override ConvertResult<PagingSettings> ConvertSupportedItem(ItemModel source)
                    {
                        var pagingSettings = new PagingSettings
                        {
                            FirstPageNumber = base.GetIntValue(source, PagingItemModel.FirstPageNumber),
                            PageSize = base.GetIntValue(source, PagingItemModel.PageSize),
                            MaximumCount = base.GetIntValue(source, PagingItemModel.MaximumCount),
                            CurrentPagePathExpression = base.GetStringValue(source, PagingItemModel.CurrentPagePathExpression),
                            PageSizePathExpression = base.GetStringValue(source, PagingItemModel.PageSizePathExpression),
                            TotalCountPathExpression = base.GetStringValue(source, PagingItemModel.TotalCountPathExpression),
                            NextTokenPathExpression = base.GetStringValue(source, PagingItemModel.NextTokenPathExpression)
                        };
            
                        return this.PositiveResult(pagingSettings);
                    }
                }
            }   
	   
   .. important:: 

       See Tip and Note from :doc:`index` for more information about ``templates.cs``.
