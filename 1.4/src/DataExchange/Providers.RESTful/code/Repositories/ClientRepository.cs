using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sitecore.DataExchange;
using DataExchange.Providers.RESTful.Extensions;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Repositories
{
    public class ClientRepository : BaseClientRepository
    {
        private static readonly WebRequestHandler Handler = new WebRequestHandler
        {
            ReadWriteTimeout = 10 * 1000
        };

        private static readonly HttpClient Client = new HttpClient(Handler);

        public override async Task<HttpResponseMessage> SendAsync(ApplicationSettings application, ResourceSettings resource)
        {
            var url = $"{application.BaseUrl}{resource.Url}";

            var plugins  = new List<IPlugin>();
            plugins.Add(application);

            if (resource.Paging != null)
                plugins.Add(resource.Paging);

            var tokens = plugins.ConvertToTokenDictionary();

            return await this.SendAsync(url, resource, tokens);
        }

        public override async Task<HttpResponseMessage> SendAsync(string url, ResourceSettings resource, Dictionary<string, string> tokens)
        {
            var headers = base.ReplaceTokens(resource.Headers, tokens);
            var parameters = base.ReplaceTokens(resource.Parameters, tokens);
            url = base.ReplaceUrlParameters(url, parameters);

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(resource.Method)
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return await Client.SendAsync(request);
        }
    }
}