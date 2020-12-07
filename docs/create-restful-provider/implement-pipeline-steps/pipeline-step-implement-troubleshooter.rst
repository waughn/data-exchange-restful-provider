Implement Read Data Pipeline Step Troubleshooter
==============================================================================

.. important:: 
    **v2.0 or later**: A troubleshooter component was introduced in v2.0 to run logic that determines whether the selected Sitecore item is configured and working properly. 
    See `Implementing a Troubleshooter <https://doc.sitecore.com/developers/def/20/data-exchange-framework/en/implementing-a-troubleshooter.html>`_ for more information.

Here are the high-level steps for the read data pipeline step troubleshooter:

  * Verifies plugins and required values
  * Calls async task to read data 
  * Gets repository settings from Data Exchange context
  * Converts settings from plugins to create request
  * Processes JSON response and deserializes into `JObject <https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm>`_
  * Uses path expression to create `JArray <https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JArray.htm>`_


1. In Visual Studio, add the following class:

   .. tip::
       Troubleshooters were originally designed for endpoints. The ``Sitecore.DataExchange.Troubleshooters.BaseEndpointTroubleshooter`` base class is available for endpoint troubleshooters, 
       but other Data Exchange items can use troubleshooters including pipeline steps.
       
   .. code-block:: c#
    
        using Sitecore.DataExchange;
        using Sitecore.DataExchange.Extensions;
        using Sitecore.DataExchange.Models;
        using Sitecore.DataExchange.Troubleshooters;
        using Sitecore.Services.Core.Model;

        namespace DataExchange.Providers.RESTful.Troubleshooters
        {
            public abstract class BasePipelineStepTroubleshooter : ITroubleshooter
            {
                public virtual ITroubleshooterResult Troubleshoot(
                    TroubleshooterContext context)
                {
                    if (context == null)
                        return TroubleshooterResult.FailResult("The context object passed to the troubleshooter is null.");

                    ItemModel configuration = context.Configuration as ItemModel;
                    if (configuration == null)
                        return TroubleshooterResult.FailResult("The configuration object on the troubleshooter context is null or could not be converted into an item model.");

                    IConverter<ItemModel, PipelineStep> converter = configuration.GetConverter<PipelineStep>(context.ItemModelRepository);
                    if (converter == null)
                        return TroubleshooterResult.FailResult(string.Format("No pipeline step converter was resolved. Item id: {0}", configuration.GetItemId().ToString()));

                    ConvertResult<PipelineStep> convertResult = converter.Convert(configuration);
                    if (!convertResult.WasConverted)
                        return TroubleshooterResult.FailResult("The configuration object on the troubleshooter context could not be converted into a pipeline step.");

                    return this.Troubleshoot(convertResult.ConvertedValue, context);
                }

                protected abstract ITroubleshooterResult Troubleshoot(
                    PipelineStep pipelineStep,
                    TroubleshooterContext context);
            }
        }
	   

2. Add the following class:

  .. code-block:: c#

      using System;
      using System.Net;
      using System.Threading.Tasks;
      using Newtonsoft.Json;
      using Newtonsoft.Json.Linq;
      using Sitecore.DataExchange;
      using Sitecore.DataExchange.Extensions;
      using Sitecore.DataExchange.Models;
      using Sitecore.DataExchange.Plugins;
      using Sitecore.DataExchange.Troubleshooters;
      using DataExchange.Providers.RESTful.Extensions;
      using DataExchange.Providers.RESTful.Plugins.Context;
      using DataExchange.Providers.RESTful.Plugins.Settings;

      namespace DataExchange.Providers.RESTful.Troubleshooters.PipelineSteps
      {
          public class ReadResourceDataTroubleshooter : BasePipelineStepTroubleshooter
          {
              protected override ITroubleshooterResult Troubleshoot(PipelineStep pipelineStep, TroubleshooterContext context)
              {
                  EndpointSettings endpointSettings = pipelineStep.GetEndpointSettings();
                  if (endpointSettings == null)
                      return TroubleshooterResult.FailResult(string.Format("Pipeline step is missing a plugin. \n Plugin: {0}", typeof(EndpointSettings).FullName));

                  Endpoint endpointFrom = endpointSettings.EndpointFrom;
                  if (endpointFrom == null)
                      return TroubleshooterResult.FailResult(string.Format("Pipeline step is missing a value. \n Property: {0}", Templates.BaseEndpointPipelineStep.FieldNames.EndpointFrom));

                  return Task.Run(async () => await this.TroubleshootReadData(endpointFrom, pipelineStep, context)).Result;
              }

              protected async Task<ITroubleshooterResult> TroubleshootReadData(Endpoint endpoint, PipelineStep pipelineStep, TroubleshooterContext context)
              {
                  if (endpoint == null)
                      throw new ArgumentNullException(nameof(endpoint));

                  if (pipelineStep == null)
                      throw new ArgumentNullException(nameof(pipelineStep));

                  if (context == null)
                      throw new ArgumentNullException(nameof(context));

                  var repositorySettings = Context.GetPlugin<RepositorySettings>();
                  if (repositorySettings == null)
                      return TroubleshooterResult.FailResult(string.Format("Context is missing a plugin. \n Plugin: {0}", typeof(RepositorySettings).FullName));

                  if (repositorySettings.Client == null)
                      return TroubleshooterResult.FailResult(string.Format("Plugin is missing a client. Check initialize pipeline. \n Plugin: {0}; Property: {1}", typeof(RepositorySettings).FullName, "Client"));

                  var applicationEndpointSettings = endpoint.GetApplicationEndpointSettings();
                  var applicationSettings = (ApplicationSettings)applicationEndpointSettings?.Application?.RefreshPlugin.Invoke();
                  if (applicationSettings == null)
                      return TroubleshooterResult.FailResult(string.Format("Endpoint is missing a value. \n Endpoint: {0} \n Property: {1}", endpoint.Name, Templates.RESTfulEndpoint.FieldNames.Application));

                  if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                      return TroubleshooterResult.FailResult(string.Format("Application is missing a value. \n Property: {0})", Templates.Application.FieldNames.BaseUrl));

                  var resourceSettings = pipelineStep.GetResourceSettings();
                  if (resourceSettings == null)
                      return TroubleshooterResult.FailResult(string.Format("Pipeline step is missing a value. \n Property: {0}", Templates.BaseResourceEndpointPipelineStep.FieldNames.Resource));

                  if (string.IsNullOrWhiteSpace(resourceSettings.Url))
                      return TroubleshooterResult.FailResult(string.Format("Resource is missing a value. \n Property: {0}", Templates.Resource.FieldNames.Url));

                  if (string.IsNullOrWhiteSpace(resourceSettings.Method))
                      return TroubleshooterResult.FailResult(string.Format("Resource is missing a value. \n Property: {0}", Templates.Resource.FieldNames.Method));

                  var readDataSettings = pipelineStep.GetReadResourceDataSettings();
                  if (readDataSettings == null || string.IsNullOrWhiteSpace(readDataSettings.PathExpression))
                      return TroubleshooterResult.FailResult(string.Format("Pipeline step is missing a value. \n Property: {0}", Templates.ReadResourceDataPipelineStep.FieldNames.PathExpression));

                  var response = await repositorySettings.Client.SendAsync(applicationSettings, resourceSettings);
                  if (response.StatusCode != HttpStatusCode.OK)
                      return TroubleshooterResult.FailResult(string.Format("Status Code: {0} \n Reason: {1}", (int)response.StatusCode, response.ReasonPhrase));

                  var content = await response.Content.ReadAsStringAsync();
                  var jObject = JsonConvert.DeserializeObject<JObject>(content);

                  if (jObject == null)
                      return TroubleshooterResult.FailResult(string.Format("No JSON data returned. \n Content: {0}", content));

                  var jArray = (JArray)jObject.SelectToken(readDataSettings.PathExpression, false);

                  if (jArray == null)
                      return TroubleshooterResult.FailResult(string.Format("No data returned from path expression. \n Content: {0}", content));


                  return TroubleshooterResult.SuccessResult(string.Format("Connection was successfully established. \n {0} row(s) were returned.", jArray.Count));
              }
          }
      }