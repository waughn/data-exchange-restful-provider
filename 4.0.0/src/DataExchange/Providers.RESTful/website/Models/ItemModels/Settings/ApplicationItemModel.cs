using Sitecore.Services.Core.Model;

namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
{
    public class ApplicationItemModel : ItemModel
    {
        public const string BaseUrl = Templates.Application.FieldNames.BaseUrl;

        public const string RefreshToken = Templates.Application.FieldNames.RefreshToken;
        public const string AccessToken = Templates.Application.FieldNames.AccessToken;
        public const string AccessTokenDate = Templates.Application.FieldNames.AccessTokenDate;
        public const string ExpiresIn = Templates.Application.FieldNames.ExpiresIn;

        public const string AuthenticationResource = Templates.Application.FieldNames.AuthenticationResource;
    }
}