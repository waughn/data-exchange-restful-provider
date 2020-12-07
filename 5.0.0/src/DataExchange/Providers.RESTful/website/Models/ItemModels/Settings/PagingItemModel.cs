using Sitecore.Services.Core.Model;

namespace DataExchange.Providers.RESTful.Models.ItemModels.Settings
{
    public class PagingItemModel : ItemModel
    {
        public const string FirstPageNumber = Templates.Paging.FieldNames.FirstPageNumber;
        public const string PageSize = Templates.Paging.FieldNames.PageSize;
        public const string MaximumCount = Templates.Paging.FieldNames.MaximumCount;
        public const string CurrentPagePathExpression = Templates.Paging.FieldNames.CurrentPagePathExpression;
        public const string PageSizePathExpression = Templates.Paging.FieldNames.PageSizePathExpression;
        public const string TotalCountPathExpression = Templates.Paging.FieldNames.TotalCountPathExpression;
        public const string NextTokenPathExpression = Templates.Paging.FieldNames.NextTokenPathExpression;
    }
}