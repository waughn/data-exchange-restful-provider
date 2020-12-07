using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Repositories
{
    public abstract class BaseClientRepository : IClientRepository
    {
        public abstract Task<HttpResponseMessage> SendAsync(ApplicationSettings application, ResourceSettings resource);
        public abstract Task<HttpResponseMessage> SendAsync(string url, ResourceSettings resource, Dictionary<string, string> tokens);

        protected Dictionary<string, string> ReplaceTokens(IEnumerable<RequestHeaderSettings> headers, IReadOnlyDictionary<string, string> tokens)
        {
            var requestHeaders = new Dictionary<string, string>();

            foreach (var header in headers)
            {
                var value = header.HeaderValue;
                var matches = Regex.Matches(header.HeaderValue, @"{[\w\d]*\.[\w\d]*}");
                foreach (Match match in matches)
                {
                    if (tokens.ContainsKey(match.Value))
                        value = value.Replace(match.Value, tokens[match.Value]);
                }

                requestHeaders.Add(header.HeaderName, value);
            }

            return requestHeaders;
        }

        protected Dictionary<string, string> ReplaceTokens(IEnumerable<RequestParameterSettings> parameters, IReadOnlyDictionary<string, string> tokens)
        {
            var requestParameters = new Dictionary<string, string>();

            foreach (var parameter in parameters)
            {
                var value = parameter.ParameterValue;
                var matches = Regex.Matches(parameter.ParameterValue, @"{[\w\d]*\.[\w\d]*}");
                foreach (Match match in matches)
                {
                    if (tokens.ContainsKey(match.Value))
                        value = value.Replace(match.Value, tokens[match.Value]);
                }

                requestParameters.Add(parameter.ParameterToken, value);
            }

            return requestParameters;
        }

        protected string ReplaceUrlParameters(string url, IReadOnlyDictionary<string, string> tokens)
        {
            foreach (var token in tokens)
            {
                url = url.Replace(token.Key, WebUtility.UrlEncode(token.Value));
            }

            return url;
        }
    }
}