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