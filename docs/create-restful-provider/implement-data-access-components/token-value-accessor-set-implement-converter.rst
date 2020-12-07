Implement Token Value Accessor Set 
=======================================

Follow these step to create the *item model* and *converter* for token value accessor set.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessorsSets
       {
           public class TokenValueAccessorSetsItemModel : ItemModel
           {
           }
       }

2. Add the following class:

   .. code-block:: c#
   
       using System;
       using System.Collections.Generic;
       using Sitecore.DataExchange;
       using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
       using Sitecore.DataExchange.Repositories;
       using Sitecore.Services.Core.Model;
       using DataExchange.Providers.RESTful.Models.ItemModels;
       using DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessors;
       
       namespace DataExchange.Providers.RESTful.Converters.DataAccess.ValueAccessorsSets
       {
           public class TokenValueAccessorSetsConverter : ChildBasedValueAccessorSetConverter, IConverter<ItemModel, ICollection<string>>
           {
               public TokenValueAccessorSetsConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.TokenValueAccessorSet.TemplateId);
               }
       
               ConvertResult<ICollection<string>> IConverter<ItemModel, ICollection<string>>.Convert(ItemModel source)
               {
                   if (!base.IsSupportedItem(source))
                       return ConvertResult<ICollection<string>>.NegativeResult(this.FormatMessageForNegativeResult(source, "The source item is not supported by this converter.", Array.Empty<string>()));
       
                   var stringSet = new HashSet<string>();
       
                   var childItemModels = this.GetChildItemModels(source);
                   if (childItemModels != null)
                   {
                       foreach (var itemModel in childItemModels)
                       {
                           var path = this.GetStringValue(itemModel, TokenValueAccessorItemModel.PathExpression);
                           if (!string.IsNullOrWhiteSpace(path) && this.GetBoolValue(itemModel, CommonItemModel.Enabled))
                               stringSet.Add(path);
                       }
                   }
       
                   return ConvertResult<ICollection<string>>.PositiveResult(stringSet);
               }
           }
       }

   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.

       .. code-block:: c#
       
           using System.Collections.Generic;
           using Sitecore.DataExchange;
           using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
           using Sitecore.DataExchange.Models.ItemModels.Common;
           using Sitecore.DataExchange.Repositories;
           using Sitecore.Services.Core.Model;
           using DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessors;
           
           namespace DataExchange.Providers.RESTful.Converters.DataAccess.ValueAccessorsSets
           {
               public class TokenValueAccessorSetsConverter : ChildBasedValueAccessorSetConverter, IConverter<ItemModel, ICollection<string>>
               {
                   public TokenValueAccessorSetsConverter(IItemModelRepository repository) : base(repository)
                   {
                       this.SupportedTemplateIds.Add(Templates.TokenValueAccessorSet.TemplateId);
                   }
           
                   ICollection<string> IConverter<ItemModel, ICollection<string>>.Convert(ItemModel source)
                   {
                       var stringSet = new HashSet<string>();
           
                       if (this.CanConvert(source))
                       {
                           var childItemModels = this.GetChildItemModels(source);
                           if (childItemModels != null)
                           {
                               foreach (var itemModel in childItemModels)
                               {
                                   var path = this.GetStringValue(itemModel, TokenValueAccessorItemModel.PathExpression);
                                   if (!string.IsNullOrWhiteSpace(path) && this.GetBoolValue(itemModel, EnableableItemModel.Enabled))
                                       stringSet.Add(path);
                               }
                           }
                       }
           
                       return stringSet;
                   }
               }
           }
       
   .. important:: 

       See Tip and Note from :doc:`../implement-tenant-settings/index` for more information about ``templates.cs``.
