using Sitecore.DataExchange;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Extensions;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using DataExchange.Providers.RESTful.Models.ItemModels.Endpoints;
using DataExchange.Providers.RESTful.Plugins.Endpoints;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Converters.Endpoints
{
    public class ApplicationEndpointConverter : BaseEndpointConverter
    {
        public ApplicationEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(Templates.RestfulEndpoint.TemplateId);
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var applicationEndpointSettings = new ApplicationEndpointSettings();
            var model = this.ConvertReferenceToModel<ApplicationSettings>(source, ApplicationEndpointItemModel.Application);
            if (model != null)
                applicationEndpointSettings.Application = model;

            if (applicationEndpointSettings.Application == null)
                Context.Logger.Error("No application was specified for the endpoint. (item: {0}, field: {1})", source.GetItemId(), Templates.RestfulEndpoint.FieldNames.Application);

            endpoint.Plugins.Add(applicationEndpointSettings);
        }
    }
}