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