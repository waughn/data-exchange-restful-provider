using Sitecore.DataExchange;

namespace DataExchange.Providers.RESTful.Plugins.Settings
{
    public class PagingSettings : IPlugin
    {
        public int FirstPageNumber { get; set; }
        public int PageSize { get; set; }
        public int MaximumCount { get; set; }
        public string CurrentPagePathExpression { get; set; }
        public string PageSizePathExpression { get; set; }
        public string TotalCountPathExpression { get; set; }
        public string NextTokenPathExpression { get; set; }
    }
}