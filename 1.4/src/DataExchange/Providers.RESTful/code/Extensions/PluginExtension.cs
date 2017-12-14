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

                foreach (var prop in properties.Where(p => (p.PropertyType == typeof(string) || p.PropertyType == typeof(int) || p.PropertyType == typeof(bool)) && p.CanRead && p.GetGetMethod(false) != null))
                {
                    var name = string.Format("{{{0}.{1}}}", prefix, prop.Name);
                    var value = GetPropertyValue(plugin, prop);

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

                    foreach (var prop in properties.Where(p => (p.PropertyType == typeof(string) || p.PropertyType == typeof(int) || p.PropertyType == typeof(bool)) && p.CanRead && p.GetGetMethod(false) != null))
                    {
                        var name = string.Format("{{{0}.{1}}}", prefix, prop.Name);
                        var value = GetPropertyValue(plugin, prop);

                        if (!tokens.ContainsKey(name))
                            tokens.Add(name, value);
                    }
                }
            }

            return tokens;
        }

        private static string GetPropertyValue(object obj, PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return (string)prop.GetValue(obj) ?? string.Empty;

            if (prop.PropertyType == typeof(int))
                return ((int)prop.GetValue(obj)).ToString();

            if (prop.PropertyType == typeof(bool))
                return ((bool)prop.GetValue(obj)).ToString();

            return string.Empty;
        }
    }
}