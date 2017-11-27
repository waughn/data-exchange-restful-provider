using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Converters.Settings
{
    public class RequestParameterConverter : BaseItemModelConverter<RequestParameterSettings>
    {
        public RequestParameterConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(Templates.RequestParameter.TemplateId);
        }

        public override RequestParameterSettings Convert(ItemModel source)
        {
            var requestParameterSettings = new RequestParameterSettings
            {
                ParameterToken = base.GetStringValue(source, RequestParameterItemModel.ParameterToken),
                ParameterValue = base.GetStringValue(source, RequestParameterItemModel.ParameterValue)
            };

            return requestParameterSettings;
        }
    }
}