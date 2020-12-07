Initialize Sitecore Provider Plugins 
=======================================

Follow these step to initialize *plugins* for Sitecore Provider for Data Exchange Framework.

.. important::
    `WebActivatorEx <https://www.nuget.org/packages/WebActivatorEx>`_ is used to execute the initialization code.

1. In Visual Studio, add the following class:

   .. code-block:: c#

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
