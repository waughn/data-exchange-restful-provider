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