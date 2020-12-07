Implement Read Data Pipeline Step Processor
==============================================================================

.. note::
    See `Pipeline Step Processor <http://integrationsdn.sitecore.net/DataExchangeFramework/v1.4/getting-started/process-modeling/pipeline-step-processor.html>`_
    for more information.

Here are the high-level steps for the read data pipeline step processor:

  * Verifies plugins and required values
  * Calls async task to read data 
  * Gets repository settings from Data Exchange context
  * Converts settings from plugins to create request
  * Processes JSON response and deserializes into `JObject <https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm>`_
  * Uses path expression to create `JArray <https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JArray.htm>`_
  * Pages through responses
  * Adds collection to *pipeline context* for next processor 


.. important:: 
    
    ``Sitecore.DataExchange.Processors.PipelineSteps.BaseReadDataStepProcessor``
    is a base type for pipeline step processors that read data; however, it currently does not 
    support asynchronous processes. 

1. In Visual Studio, add the following class:

   .. code-block:: c#
   
        using System;
        using System.Threading.Tasks;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using Sitecore.DataExchange;
        using Sitecore.DataExchange.Attributes;
        using Sitecore.DataExchange.Contexts;
        using Sitecore.DataExchange.Extensions;
        using Sitecore.DataExchange.Models;
        using Sitecore.DataExchange.Plugins;
        using Sitecore.DataExchange.Processors.PipelineSteps;
        using Sitecore.Services.Core.Diagnostics;
        using DataExchange.Providers.RESTful.Extensions;
        using DataExchange.Providers.RESTful.Plugins.Context;
        using DataExchange.Providers.RESTful.Plugins.Endpoints;
        using DataExchange.Providers.RESTful.Plugins.Processors;
        using DataExchange.Providers.RESTful.Plugins.Settings;
        
        namespace DataExchange.Providers.RESTful.Processors.PipelineSteps
        {
            [RequiredPipelineStepPlugins(typeof(EndpointSettings), typeof(ReadResourceDataSettings))]
            [RequiredEndpointPlugins(typeof(ApplicationEndpointSettings))]
            public class ReadResourceDataPipelineStep : BasePipelineStepWithEndpointsProcessor
            {
                protected override void ProcessPipelineStep(PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
                {
                    EndpointSettings endpointSettings = pipelineStep.GetEndpointSettings();
                    if (endpointSettings == null)
                    {
                        logger.Error("Pipeline step processing will abort because the pipeline step is missing a plugin. (pipeline step: {0}, plugin: {1})", pipelineStep.Name,
                            typeof(EndpointSettings).FullName);
                    }
                    else
                    {
                        ReadResourceDataSettings readDataSettings = pipelineStep.GetReadResourceDataSettings();
                        if (readDataSettings == null)
                        {
                            this.Log(logger.Error, pipelineContext, "Pipeline step processing will abort because the pipeline step is missing a plugin.", string.Format("plugin: {0}", typeof(ReadResourceDataSettings).FullName));
                        }
                        else
                        {
                            Endpoint endpointFrom = endpointSettings.EndpointFrom;
                            if (endpointFrom == null)
                            {
                                logger.Error(
                                    "Pipeline step processing will abort because the pipeline step is missing an endpoint to read from. (pipeline step: {0}, plugin: {1}, property: {2})",
                                    pipelineStep.Name, typeof(EndpointSettings).FullName, "EndpointFrom");
                            }
                            else if (!this.IsEndpointValid(endpointFrom, pipelineStep, pipelineContext, logger))
                            {
                                logger.Error("Pipeline step processing will abort because the endpoint to read from is not valid. (pipeline step: {0}, endpoint: {1})",
                                    pipelineStep.Name,
                                    endpointFrom.Name);
                            }
                            else
                            {
                                logger.Info("Pipeline step reading data. (pipeline step: {0}, plugin: {1})", pipelineStep.Name, typeof(EndpointSettings).FullName);
        
                                var dataRead = Task.Run<bool>(async () => await this.ReadData(endpointFrom, pipelineStep, pipelineContext, logger)).Result;
        
                                logger.Info("Pipeline context has data? {0} (pipeline step: {1}, plugin: {2})", pipelineContext.HasIterableDataSettings(), pipelineStep.Name, typeof(EndpointSettings).FullName);
                            }
                        }
                    }
                }
        
                protected async Task<bool> ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
                {
                    if (endpoint == null)
                    {
                        throw new ArgumentNullException(nameof(endpoint));
                    }
        
                    if (pipelineStep == null)
                    {
                        throw new ArgumentNullException(nameof(pipelineStep));
                    }
        
                    if (pipelineContext == null)
                    {
                        throw new ArgumentNullException(nameof(pipelineContext));
                    }
        
                    var repositorySettings = Context.GetPlugin<RepositorySettings>();
                    if (repositorySettings == null)
                    {
                        logger.Error("No repository settings plugin is specified on the context (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    if (repositorySettings.Client == null)
                    {
                        logger.Error("No client is specified on the repository settings (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    var applicationEndpointSettings = endpoint.GetApplicationEndpointSettings();
                    var applicationSettings = (ApplicationSettings)applicationEndpointSettings?.Application?.RefreshPlugin.Invoke();
        
                    if (applicationSettings == null)
                    {
                        logger.Error("No application is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                    {
                        logger.Error("No Base Url is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    if (string.IsNullOrWhiteSpace(applicationSettings.AccessToken))
                    {
                        logger.Warn("No access token is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        //return false;
                    }
        
                    var resourceSettings = pipelineStep.GetResourceSettings();
        
                    if (resourceSettings == null)
                    {
                        logger.Error("No resource is specified on the pipeline step (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    if (string.IsNullOrWhiteSpace(resourceSettings.Url))
                    {
                        logger.Error("No url is specified on the resource (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    if (string.IsNullOrWhiteSpace(resourceSettings.Method))
                    {
                        logger.Error("No method is specified on the resource (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    var readDataSettings = pipelineStep.GetReadResourceDataSettings();
        
                    if (readDataSettings == null || string.IsNullOrWhiteSpace(readDataSettings.PathExpression))
                    {
                        logger.Error("No path expression is specified on the pipeline step. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        return false;
                    }
        
                    var iterableData = new JArray();
                    bool hasMore;
        
                    do
                    {
                        hasMore = false;
        
                        var response = await repositorySettings.Client.SendAsync(applicationSettings, resourceSettings);
                        var json = await response.Content.ReadAsStringAsync();
                        var jObject = JsonConvert.DeserializeObject<JObject>(json);
        
                        if (jObject == null)
                        {
                            logger.Debug("No data returned from request. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                        }
                        else
                        {
                            var jArray = (JArray)jObject.SelectToken(readDataSettings.PathExpression, false);
        
                            if (jArray == null)
                            {
                                logger.Debug("No data returned from path expression. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                            }
                            else if (jArray.Count == 0)
                            {
                                logger.Info("No items returned from request. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                            }
                            else
                            {
                                logger.Info("{0} rows were read from endpoint. (pipeline step: {1}, endpoint: {2})", jArray.Count, pipelineStep.Name, endpoint.Name);
                                iterableData.Merge(jArray);
        
                                if (resourceSettings.Paging != null)
                                {
                                    if (!string.IsNullOrEmpty(resourceSettings.Paging.NextTokenPathExpression))
                                    {
                                        var nextToken = jObject.SelectToken(resourceSettings.Paging.NextTokenPathExpression, false);
        
                                        resourceSettings.Paging.NextToken = nextToken?.Value<string>();
        
                                        hasMore = !string.IsNullOrEmpty(nextToken?.Value<string>());
                                    }
                                    else
                                    {
                                        var pageToken = jObject.SelectToken(resourceSettings.Paging.CurrentPagePathExpression, false);
                                        var pageSizeToken = jObject.SelectToken(resourceSettings.Paging.PageSizePathExpression, false);
                                        var totalCountToken = jObject.SelectToken(resourceSettings.Paging.TotalCountPathExpression, false);
        
                                        var page = pageToken?.Value<int?>() ?? 0;
                                        var pageSize = pageSizeToken?.Value<int?>() ?? resourceSettings.Paging.PageSize;
                                        var totalCount = totalCountToken?.Value<int?>() ?? int.MinValue;
                                        var maxCount = resourceSettings.Paging.MaximumCount;
        
                                        resourceSettings.Paging.Page = page + 1;
                                        resourceSettings.Paging.PageSize = pageSize;
                                        resourceSettings.Paging.TotalCount = totalCount;
        
                                        hasMore = page * pageSize > 0
                                            && page * pageSize < totalCount
                                            && page * pageSize < maxCount;
                                    }
                                }
                            }
                        }
        
                    } while (resourceSettings.Paging != null && hasMore);
        
                    logger.Info("{0} total rows were read from endpoint. (pipeline step: {1}, endpoint: {2})", iterableData.Count, pipelineStep.Name, endpoint.Name);
        
                    var dataSettings = new IterableDataSettings(iterableData);
        
                    pipelineContext.AddPlugins(dataSettings);
        
                    return true;
                }
            }
        }

  
   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.Processors.PipelineSteps.BasePipelineStepProcessor`` base class was updated. ``Process(PipelineStep pipelineStep, PipelineContext pipelineContext)`` was replaced with ``ProcessPipelineStep(PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)``.
     
       .. code-block:: c#
        
           using System;
           using System.Threading.Tasks;
           using Newtonsoft.Json;
           using Newtonsoft.Json.Linq;
           using Sitecore.DataExchange;
           using Sitecore.DataExchange.Attributes;
           using Sitecore.DataExchange.Contexts;
           using Sitecore.DataExchange.Extensions;
           using Sitecore.DataExchange.Models;
           using Sitecore.DataExchange.Plugins;
           using Sitecore.DataExchange.Processors.PipelineSteps;
           using DataExchange.Providers.RESTful.Extensions;
           using DataExchange.Providers.RESTful.Plugins.Context;
           using DataExchange.Providers.RESTful.Plugins.Endpoints;
           using DataExchange.Providers.RESTful.Plugins.Processors;
           using DataExchange.Providers.RESTful.Plugins.Settings;
           
           namespace DataExchange.Providers.RESTful.Processors.PipelineSteps
           {
               [RequiredPipelineStepPlugins(typeof(EndpointSettings), typeof(ReadResourceDataSettings))]
               [RequiredEndpointPlugins(typeof(ApplicationEndpointSettings))]
               public class ReadResourceDataPipelineStep : BasePipelineStepWithEndpointsProcessor
               {
                   public override void Process(PipelineStep pipelineStep, PipelineContext pipelineContext)
                   {
                       var logger = pipelineContext.PipelineBatchContext.Logger;
           
                       if (!this.CanProcess(pipelineStep, pipelineContext))
                       {
                           logger.Error("Pipeline step processing will abort because the pipeline step cannot be processed. (pipeline step: {0})", pipelineStep.Name);
                       }
                       else
                       {
                           EndpointSettings endpointSettings = pipelineStep.GetEndpointSettings();
                           if (endpointSettings == null)
                           {
                               logger.Error("Pipeline step processing will abort because the pipeline step is missing a plugin. (pipeline step: {0}, plugin: {1})", pipelineStep.Name,
                                   typeof(EndpointSettings).FullName);
                           }
                           else
                           {
                               ReadResourceDataSettings readDataSettings = pipelineStep.GetReadResourceDataSettings();
                               if (readDataSettings == null)
                               {
                                   this.Log(logger.Error, pipelineContext, "Pipeline step processing will abort because the pipeline step is missing a plugin.", string.Format("plugin: {0}", typeof(ReadResourceDataSettings).FullName));
                               }
                               else
                               {
                                   Endpoint endpointFrom = endpointSettings.EndpointFrom;
                                   if (endpointFrom == null)
                                   {
                                       logger.Error(
                                           "Pipeline step processing will abort because the pipeline step is missing an endpoint to read from. (pipeline step: {0}, plugin: {1}, property: {2})",
                                           pipelineStep.Name, typeof(EndpointSettings).FullName, "EndpointFrom");
                                   }
                                   else if (!this.IsEndpointValid(endpointFrom, pipelineStep, pipelineContext))
                                   {
                                       logger.Error("Pipeline step processing will abort because the endpoint to read from is not valid. (pipeline step: {0}, endpoint: {1})",
                                           pipelineStep.Name,
                                           endpointFrom.Name);
                                   }
                                   else
                                   {
                                       logger.Info("Pipeline step reading data. (pipeline step: {0}, plugin: {1})", pipelineStep.Name, typeof(EndpointSettings).FullName);
           
                                       var dataRead = Task.Run<bool>(async () => await this.ReadData(endpointFrom, pipelineStep, pipelineContext)).Result;
           
                                       logger.Info("Pipeline context has iterable data? {0} (pipeline step: {1}, plugin: {2})", pipelineContext.HasIterableDataSettings(), pipelineStep.Name, typeof(EndpointSettings).FullName);
                                   }
                               }
                           }
                       }
                   }
           
                   protected async Task<bool> ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext)
                   {
                       if (endpoint == null)
                       {
                           throw new ArgumentNullException(nameof(endpoint));
                       }
           
                       if (pipelineStep == null)
                       {
                           throw new ArgumentNullException(nameof(pipelineStep));
                       }
           
                       if (pipelineContext == null)
                       {
                           throw new ArgumentNullException(nameof(pipelineContext));
                       }
           
                       var logger = pipelineContext.PipelineBatchContext.Logger;
           
                       var repositorySettings = Context.GetPlugin<RepositorySettings>();
                       if (repositorySettings == null)
                       {
                           logger.Error("No repository settings plugin is specified on the context (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       if (repositorySettings.Client == null)
                       {
                           logger.Error("No client is specified on the repository settings (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       var applicationEndpointSettings = endpoint.GetApplicationEndpointSettings();
                       var applicationSettings = (ApplicationSettings)applicationEndpointSettings?.Application?.RefreshPlugin.Invoke();
           
                       if (applicationSettings == null)
                       {
                           logger.Error("No application is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       if (string.IsNullOrWhiteSpace(applicationSettings.BaseUrl))
                       {
                           logger.Error("No Base Url is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       if (string.IsNullOrWhiteSpace(applicationSettings.AccessToken))
                       {
                           logger.Warn("No access token is specified on the endpoint (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           //return false;
                       }
           
                       var resourceSettings = pipelineStep.GetResourceSettings();
           
                       if (resourceSettings == null)
                       {
                           logger.Error("No resource is specified on the pipeline step (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       if (string.IsNullOrWhiteSpace(resourceSettings.Url))
                       {
                           logger.Error("No url is specified on the resource (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       if (string.IsNullOrWhiteSpace(resourceSettings.Method))
                       {
                           logger.Error("No method is specified on the resource (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       var readDataSettings = pipelineStep.GetReadResourceDataSettings();
           
                       if (readDataSettings == null || string.IsNullOrWhiteSpace(readDataSettings.PathExpression))
                       {
                           logger.Error("No path expression is specified on the pipeline step. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           return false;
                       }
           
                       var iterableData = new JArray();
                       bool hasMore;
           
                       do
                       {
                           hasMore = false;
           
                           var response = await repositorySettings.Client.SendAsync(applicationSettings, resourceSettings);
                           var json = await response.Content.ReadAsStringAsync();
                           var jObject = JsonConvert.DeserializeObject<JObject>(json);
           
                           if (jObject == null)
                           {
                               logger.Debug("No data returned from request. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                           }
                           else
                           {
                               var jArray = (JArray)jObject.SelectToken(readDataSettings.PathExpression, false);
           
                               if (jArray == null)
                               {
                                   logger.Debug("No data returned from path expression. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                               }
                               else if (jArray.Count == 0)
                               {
                                   logger.Info("No items returned from request. (pipeline step: {0}, endpoint: {1})", pipelineStep.Name, endpoint.Name);
                               }
                               else
                               {
                                   logger.Info("{0} rows were read from endpoint. (pipeline step: {1}, endpoint: {2})", jArray.Count, pipelineStep.Name, endpoint.Name);
                                   iterableData.Merge(jArray);
           
                                   if (resourceSettings.Paging != null)
                                   {
                                       if (!string.IsNullOrEmpty(resourceSettings.Paging.NextTokenPathExpression))
                                       {
                                           var nextToken = jObject.SelectToken(resourceSettings.Paging.NextTokenPathExpression, false);
           
                                           resourceSettings.Paging.NextToken = nextToken?.Value<string>();
           
                                           hasMore = !string.IsNullOrEmpty(nextToken?.Value<string>());
                                       }
                                       else
                                       {
                                           var pageToken = jObject.SelectToken(resourceSettings.Paging.CurrentPagePathExpression, false);
                                           var pageSizeToken = jObject.SelectToken(resourceSettings.Paging.PageSizePathExpression, false);
                                           var totalCountToken = jObject.SelectToken(resourceSettings.Paging.TotalCountPathExpression, false);
           
                                           var page = pageToken?.Value<int?>() ?? 0;
                                           var pageSize = pageSizeToken?.Value<int?>() ?? resourceSettings.Paging.PageSize;
                                           var totalCount = totalCountToken?.Value<int?>() ?? int.MinValue;
                                           var maxCount = resourceSettings.Paging.MaximumCount;
           
                                           resourceSettings.Paging.Page = page + 1;
                                           resourceSettings.Paging.PageSize = pageSize;
                                           resourceSettings.Paging.TotalCount = totalCount;
           
                                           hasMore = page * pageSize > 0
                                               && page * pageSize < totalCount
                                               && page * pageSize < maxCount;
                                       }
                                   }
                               }
                           }
           
                       } while (resourceSettings.Paging != null && hasMore);
           
                       logger.Info("{0} total rows were read from endpoint. (pipeline step: {1}, endpoint: {2})", iterableData.Count, pipelineStep.Name, endpoint.Name);
           
                       var dataSettings = new IterableDataSettings(iterableData);
           
                       pipelineContext.Plugins.Add(dataSettings);
           
                       return true;
                   }
               }
           }
