using Sitecore.Services.Core.Model;

namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
{
    public class ResourceItemModel : ItemModel
    {
        public const string ResourceUrl = Templates.Resource.FieldNames.Url;
        public const string Method = Templates.Resource.FieldNames.Method;
        public const string Headers = Templates.Resource.FieldNames.Headers;
        public const string Parameters = Templates.Resource.FieldNames.Parameters;
        public const string Paging = Templates.Resource.FieldNames.Paging;
    }
}