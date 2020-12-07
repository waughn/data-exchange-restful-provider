﻿using System;
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