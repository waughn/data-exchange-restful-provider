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
                return TroubleshooterResult.FailResult(string.Format("Endpoint is missing a value. \n Endpoint: {0} \n Property: {1}", endpoint.Name, Templates.RestfulEndpoint.FieldNames.Application));

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