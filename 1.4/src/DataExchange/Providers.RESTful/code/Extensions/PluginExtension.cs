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