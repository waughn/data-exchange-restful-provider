using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Repositories;
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

        public override RequestHeaderSettings Convert(ItemModel source)
        {
            var requestHeaderSettings = new RequestHeaderSettings
            {
                HeaderName = base.GetStringValue(source, RequestHeaderItemModel.HeaderName),
                HeaderValue = base.GetStringValue(source, RequestHeaderItemModel.HeaderValue)
            };

            return requestHeaderSettings;
        }
    }
}