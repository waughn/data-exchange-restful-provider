Implement Repository 
=======================================

A repository is used to send HTTP requests and receive HTTP responses from a resource. 

.. note::
    The `HttpClient <https://msdn.microsoft.com/en-us/library/system.net.http.httpclient.aspx>`_ provides a base class for sending HTTP requests 
    and receiving HTTP responses from a resource identified by a URI. A single instance of ``HttpClient`` is shared with the Data Exchange Framework for the provider.

1. In Visual Studio, add the following class:

   .. code-block:: c#

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

2. Add the following class:

   .. note::
       These *plugin* extension methods create  token values for repository in the ``{Type.PropertyName}`` format.

   .. code-block:: c#

       using System.Collections.Generic;
       using System.Linq;
       using System.Reflection;
       using Sitecore.DataExchange;
       
       namespace DataExchange.Providers.RESTful.Extensions
       {
           public static class PluginExtension
           {
               public static Dictionary<string, string> ConvertToTokenDictionary(this IPlugin plugin)
               {
                   var tokens = new Dictionary<string, string>();
       
                   if (plugin != null)
                   {
                       var prefix = plugin.GetType().Name.TrimEnd().Replace("Settings", string.Empty);
                       var properties = plugin.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
       
                       foreach (var prop in properties.Where(p => p.PropertyType == typeof(string) && p.CanRead && p.GetGetMethod(false) != null))
                       {
                           string name = string.Format("{{{0}.{1}}}", prefix, prop.Name);
                           string value = (string)prop.GetValue(plugin) ?? string.Empty;
       
                           if (!tokens.ContainsKey(name))
                               tokens.Add(name, value);
                       }
                   }
       
                   return tokens;
               }
       
               public static Dictionary<string, string> ConvertToTokenDictionary(this IEnumerable<IPlugin> plugins)
               {
                   var tokens = new Dictionary<string, string>();
       
                   if (plugins != null)
                   {
                       foreach (var plugin in plugins)
                       {
                           var prefix = plugin.GetType().Name.TrimEnd().Replace("Settings", string.Empty);
                           var properties = plugin.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
       
                           foreach (var prop in properties.Where(p => p.PropertyType == typeof(string) && p.CanRead && p.GetGetMethod(false) != null))
                           {
                               string name = string.Format("{{{0}.{1}}}", prefix, prop.Name);
                               string value = (string)prop.GetValue(plugin) ?? string.Empty;
       
                               if (!tokens.ContainsKey(name))
                                   tokens.Add(name, value);
                           }
                       }
                   }
       
                   return tokens;
               }
           }
       }
       
3. Add the following class:

   .. note::
       The base repository provides methods to convert header and parameter settings into values for the request.

   .. code-block:: c#

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
       
4. Add the following class:

   .. code-block:: c#

       using System;
       using System.Collections.Generic;
       using System.Net.Http;
       using System.Threading.Tasks;
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
                   var tokens = application.ConvertToTokenDictionary();
       
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