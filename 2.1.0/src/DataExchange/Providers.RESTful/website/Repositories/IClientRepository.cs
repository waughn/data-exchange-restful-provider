using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Repositories
{
    public interface IClientRepository
    {
        Task<HttpResponseMessage> SendAsync(ApplicationSettings application, ResourceSettings resource);

        Task<HttpResponseMessage> SendAsync(string url, ResourceSettings resource, Dictionary<string, string> tokens);
    }
}