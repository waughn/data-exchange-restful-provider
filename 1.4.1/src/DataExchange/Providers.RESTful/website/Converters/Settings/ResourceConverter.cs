using System.Collections.Generic;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Extensions;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Converters.Settings
{
    public class ResourceConverter : BaseItemModelConverter<ResourceSettings>
    {
        public ResourceConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(Templates.Resource.TemplateId);
        }

        public override ResourceSettings Convert(ItemModel source)
        {
            var resourceSettings = new ResourceSettings
            {
                Url = base.GetStringValue(source, ResourceItemModel.ResourceUrl),
                Method = base.GetStringValue(source, ResourceItemModel.Method),
                Headers = base.ConvertReferencesToModels<RequestHeaderSettings>(source, ResourceItemModel.Headers) ?? new List<RequestHeaderSettings>(),
                Parameters = base.ConvertReferencesToModels<RequestParameterSettings>(source, ResourceItemModel.Parameters) ?? new List<RequestParameterSettings>(),
                Paging = base.ConvertReferenceToModel<PagingSettings>(source, ResourceItemModel.Paging)
            };

            if (resourceSettings.Url == null)
                Context.Logger.Error("No Url was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Url);

            if (resourceSettings.Method == null)
                Context.Logger.Error("No method was specified in resource settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Resource.FieldNames.Method);

            return resourceSettings;
        }
    }
}