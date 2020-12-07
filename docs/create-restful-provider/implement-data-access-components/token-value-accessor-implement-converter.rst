Implement Token Value Accessor 
=======================================

Follow these step to create the *item model* and *converter* for token value accessor.

1. In Visual Studio, add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessors
       {
           public class TokenValueAccessorItemModel : ItemModel
           {
               public const string PathExpression = Templates.TokenValueAccessor.FieldNames.PathExpression;
           }
       }

2. Add the following class:

   .. code-block:: c#
   
       using System;
       using Sitecore.DataExchange;
       using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
       using Sitecore.DataExchange.DataAccess;
       using Sitecore.DataExchange.DataAccess.Writers;
       using Sitecore.DataExchange.Repositories;
       using Sitecore.Services.Core.Model;
       using DataExchange.Providers.RESTful.DataAccess.Readers;
       using DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessors;
       
       namespace DataExchange.Providers.RESTful.Converters.DataAccess.ValueAccessors
       {
           public class TokenValueAccessorConverter : ValueAccessorConverter
           {
               public TokenValueAccessorConverter(IItemModelRepository repository) : base(repository)
               {
                   this.SupportedTemplateIds.Add(Templates.TokenValueAccessor.TemplateId);
               }
       
               protected override ConvertResult<IValueAccessor> ConvertSupportedItem(ItemModel source)
               {
                   var convertResult = base.ConvertSupportedItem(source);
       
                   if (!convertResult.WasConverted)
                       return convertResult;
       
                   if (convertResult.ConvertedValue == null)
                       return base.NegativeResult(source, "The converted value accessor is null.", Array.Empty<string>());
       
                   var path = base.GetStringValue(source, TokenValueAccessorItemModel.PathExpression);
       
                   if (string.IsNullOrWhiteSpace(path))
                       return base.NegativeResult(source, "No path name was found.", string.Format("field: {0}", TokenValueAccessorItemModel.PathExpression));
       
                   var convertedValue = convertResult.ConvertedValue;
       
                   if (convertedValue.ValueReader == null)
                   {
                       convertedValue.ValueReader = new TokenValueReader(path);
                   }
                   if (convertedValue.ValueWriter == null)
                   {
                       convertedValue.ValueWriter = new PropertyValueWriter(path);
                   }
       
                   return convertResult;
               }
           }
       }

   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.ConvertResult`` class was introduced in Data Exchange Framework 2.0, and the ``Converter`` classes were updated to use the ``ConvertResult`` class to track positive and negative results.
     
       .. code-block:: c#
       
           using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
           using Sitecore.DataExchange.DataAccess;
           using Sitecore.DataExchange.DataAccess.Writers;
           using Sitecore.DataExchange.Repositories;
           using Sitecore.Services.Core.Model;
           using DataExchange.Providers.RESTful.DataAccess.Readers;
           using DataExchange.Providers.RESTful.Models.ItemModels.DataAccess.ValueAccessors;
           
           namespace DataExchange.Providers.RESTful.Converters.DataAccess.ValueAccessors
           {
               public class TokenValueAccessorConverter : ValueAccessorConverter
               {
                   public TokenValueAccessorConverter(IItemModelRepository repository) : base(repository)
                   {
                       this.SupportedTemplateIds.Add(Templates.TokenValueAccessor.TemplateId);
                   }
           
                   public override IValueAccessor Convert(ItemModel source)
                   {
                       var accessor = base.Convert(source);
           
                       if (accessor == null)
                           return null;
           
                       var path = base.GetStringValue(source, TokenValueAccessorItemModel.PathExpression);
           
                       if (string.IsNullOrWhiteSpace(path))
                           return null;
           
                       if (accessor.ValueReader == null)
                       {
                           accessor.ValueReader = new TokenValueReader(path);
                       }
                       if (accessor.ValueWriter == null)
                       {
                           accessor.ValueWriter = new PropertyValueWriter(path);
                       }
           
                       return accessor;
                   }
               }
           }
     
   .. important:: 

       See Tip and Note from :doc:`../implement-tenant-settings/index` for more information about ``templates.cs``.
