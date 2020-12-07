using System;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Extensions;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using DataExchange.Providers.RESTful.Models.ItemModels.Settings;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Converters.Settings
{
    public class ApplicationConverter : BaseItemModelConverter<ApplicationSettings>
    {
        public ApplicationConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(Templates.Application.TemplateId);
        }

        protected override ConvertResult<ApplicationSettings> ConvertSupportedItem(ItemModel source)
        {
            return this.PositiveResult(this.ConvertApplicationSettings(source));
        }

        protected ApplicationSettings RefreshPlugin(Guid itemId)
        {
            ApplicationSettings applicationSettings = null;

            if (this.ItemModelRepository != null)
            {
                var source = this.ItemModelRepository.Get(itemId);
                applicationSettings = this.ConvertApplicationSettings(source);
            }

            return applicationSettings;
        }

        protected ApplicationSettings ConvertApplicationSettings(ItemModel source)
        {
            var applicationSettings = new ApplicationSettings
            {
                ItemId = source.GetItemId(), 
                BaseUrl = base.GetStringValue(source, ApplicationItemModel.BaseUrl),
                RefreshToken = base.GetStringValue(source, ApplicationItemModel.RefreshToken),
                AccessToken = base.GetStringValue(source, ApplicationItemModel.AccessToken),
                AccessTokenDate = base.GetDateTimeValue(source, ApplicationItemModel.AccessTokenDate),
                ExpiresIn = base.GetIntValue(source, ApplicationItemModel.ExpiresIn),
                RefreshPlugin = () => this.RefreshPlugin(source.GetItemId())
            };

            var resource = this.ConvertReferenceToModel<ResourceSettings>(source, ApplicationItemModel.AuthenticationResource);
            if (resource != null)
                applicationSettings.AuthenticationResource = resource;

            if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                Context.Logger.Warn("No Base Url was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.BaseUrl);

            if (string.IsNullOrWhiteSpace(applicationSettings.RefreshToken))
                Context.Logger.Warn("No refresh token was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.RefreshToken);

            if (applicationSettings.AuthenticationResource == null)
                Context.Logger.Warn("No authentication resource was specified in application settings. (item: {0}, field: {1})", source.GetItemId(), Templates.Application.FieldNames.AuthenticationResource);

            return applicationSettings;
        }
    }
}