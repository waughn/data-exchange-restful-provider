using System;
using System.Text.RegularExpressions;
using Serilog;
using Sitecore.DataExchange;
using Sitecore.DataExchange.Providers.Sc.Plugins;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DataExchange.Providers.Sc.Web.Initialize), "Register")]
namespace DataExchange.Providers.Sc.Web
{
    public class Initialize
    {
        public static void Register()
        {
            try
            {
                Context.Plugins.Add(new SitecoreItemUtilities()
                {
                    IsItemNameValid = x => Regex.Matches(x, @"[^A-Za-z0-9\s]+").Count == 0,
                    ProposeValidItemName = x => Regex.Replace(x, @"[^A-Za-z0-9]+", " ").Trim(' ')
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during initialization.");
            }
        }
    }
}
