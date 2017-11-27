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