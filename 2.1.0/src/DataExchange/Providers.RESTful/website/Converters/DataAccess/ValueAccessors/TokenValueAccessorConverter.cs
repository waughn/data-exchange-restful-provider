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