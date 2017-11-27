Implement Pipeline Step
=======================================

Follow these step to create the *plugin*, *item model*, *converter* and extension methods.

1. In Visual Studio, add the following class:

   .. code-block:: c#
   
       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.PipelineSteps
       {
           public class BaseEndpointPipelineStepItemModel : ItemModel
           {
               public const string EndpointFrom = Templates.BaseEndpointPipelineStep.FieldNames.EndpointFrom;
           }
       }

2. Add the following class:

  .. code-block:: c#

      using Sitecore.Services.Core.Model;
      
      namespace DataExchange.Providers.RESTful.Models.ItemModels.PipelineSteps
      {
          public class BaseResourceEndpointPipelineStepItemModel : ItemModel
          {
              public const string Resource = Templates.BaseResourceEndpointPipelineStep.FieldNames.Resource;
          }
      }

3. Add the following class:

   .. code-block:: c#

       using Sitecore.Services.Core.Model;
       
       namespace DataExchange.Providers.RESTful.Models.ItemModels.PipelineSteps
       {
           public class ReadResourceDataPipelineStepItemModel : ItemModel
           {
               public const string PathExpression = Templates.ReadResourceDataPipelineStep.FieldNames.PathExpression;
           }
       }

4. Add the following class:

   .. tip::
       Use a base class for pipeline step converters to manage adding plugins. While it is not necessary when there
       is only one pipeline step, it becomes valuable when more steps are added.
   
   .. code-block:: c#

     using Sitecore.DataExchange;
     using Sitecore.DataExchange.Converters.PipelineSteps;
     using Sitecore.DataExchange.Extensions;
     using Sitecore.DataExchange.Models;
     using Sitecore.DataExchange.Plugins;
     using Sitecore.DataExchange.Repositories;
     using Sitecore.Services.Core.Model;
     using DataExchange.Providers.RESTful.Models.ItemModels.PipelineSteps;
     using DataExchange.Providers.RESTful.Plugins.Processors;
     using DataExchange.Providers.RESTful.Plugins.Settings;
     
     namespace DataExchange.Providers.RESTful.Converters.PipelineSteps
     {
         public abstract class BasePluginPipelineStepConverter : BasePipelineStepConverter
         {
             protected BasePluginPipelineStepConverter(IItemModelRepository repository) : base(repository)
             {
             }
     
             public void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
             {
                 var endpointSettings = new EndpointSettings();
                 var model = this.ConvertReferenceToModel<Endpoint>(source, BaseEndpointPipelineStepItemModel.EndpointFrom);
     
                 if (model != null)
                     endpointSettings.EndpointFrom = model;
     
                 if (endpointSettings.EndpointFrom == null)
                     Context.Logger.Error("No endpoint from was specified for the pipeline step. (item: {0}, field: {1})", source.GetItemId(), Templates.BaseEndpointPipelineStep.FieldNames.EndpointFrom);
     
                 pipelineStep.Plugins.Add(endpointSettings);
             }
     
             public void AddResourceSettings(ItemModel source, PipelineStep pipelineStep)
             {
                 var resourceSettings = this.ConvertReferenceToModel<ResourceSettings>(source, BaseResourceEndpointPipelineStepItemModel.Resource);
     
                 if (resourceSettings == null)
                     Context.Logger.Error("No resource was specified for the pipeline step. (item: {0}, field: {1})", source.GetItemId(), Templates.BaseResourceEndpointPipelineStep.FieldNames.Resource);
                 else
                     pipelineStep.Plugins.Add(resourceSettings);
             }
     
             protected void AddReadResourceDataSettings(ItemModel source, PipelineStep pipelineStep)
             {
                 var readResourceDataSettings = new ReadResourceDataSettings
                 {
                     PathExpression = this.GetStringValue(source, ReadResourceDataPipelineStepItemModel.PathExpression)
                 };
     
                 pipelineStep.Plugins.Add(readResourceDataSettings);
             }
         }
     }

   .. important:: 
       **v2.0**: The ``Sitecore.DataExchange.IHasPlugins`` interface was updated.
     
       .. code-block:: c#
     
            using Sitecore.DataExchange;
            using Sitecore.DataExchange.Converters.PipelineSteps;
            using Sitecore.DataExchange.Extensions;
            using Sitecore.DataExchange.Models;
            using Sitecore.DataExchange.Plugins;
            using Sitecore.DataExchange.Repositories;
            using Sitecore.Services.Core.Model;
            using DataExchange.Providers.RESTful.Models.ItemModels.PipelineSteps;
            using DataExchange.Providers.RESTful.Plugins.Processors;
            using DataExchange.Providers.RESTful.Plugins.Settings;
            
            namespace DataExchange.Providers.RESTful.Converters.PipelineSteps
            {
                public abstract class BasePluginPipelineStepConverter : BasePipelineStepConverter
                {
                    protected BasePluginPipelineStepConverter(IItemModelRepository repository) : base(repository)
                    {
                    }
            
                    public void AddEndpointSettings(ItemModel source, PipelineStep pipelineStep)
                    {
                        var endpointSettings = new EndpointSettings();
                        var model = this.ConvertReferenceToModel<Endpoint>(source, BaseEndpointPipelineStepItemModel.EndpointFrom);
            
                        if (model != null)
                            endpointSettings.EndpointFrom = model;
            
                        if (endpointSettings.EndpointFrom == null)
                            Context.Logger.Error("No endpoint from was specified for the pipeline step. (item: {0}, field: {1})", source.GetItemId(), Templates.BaseEndpointPipelineStep.FieldNames.EndpointFrom);
            
                        pipelineStep.AddPlugin<EndpointSettings>(endpointSettings);
                    }
            
                    public void AddResourceSettings(ItemModel source, PipelineStep pipelineStep)
                    {
                        var resourceSettings = this.ConvertReferenceToModel<ResourceSettings>(source, BaseResourceEndpointPipelineStepItemModel.Resource);
            
                        if (resourceSettings == null)
                            Context.Logger.Error("No resource was specified for the pipeline step. (item: {0}, field: {1})", source.GetItemId(), Templates.BaseResourceEndpointPipelineStep.FieldNames.Resource);
                        else
                            pipelineStep.AddPlugin<ResourceSettings>(resourceSettings);
                    }
            
                    protected void AddReadResourceDataSettings(ItemModel source, PipelineStep pipelineStep)
                    {
                        var readResourceDataSettings = new ReadResourceDataSettings
                        {
                            PathExpression = this.GetStringValue(source, ReadResourceDataPipelineStepItemModel.PathExpression)
                        };
            
                        pipelineStep.AddPlugin<ReadResourceDataSettings>(readResourceDataSettings);
                    }
                }
            }
	 
5. Add the following class:

   .. code-block:: c#

      using Sitecore.DataExchange.Models;
      using Sitecore.DataExchange.Repositories;
      using Sitecore.Services.Core.Model;
      
      namespace DataExchange.Providers.RESTful.Converters.PipelineSteps
      {
          public class ReadResourceDataStepConverter : BasePluginPipelineStepConverter
          {
              public ReadResourceDataStepConverter(IItemModelRepository repository) : base(repository)
              {
                  this.SupportedTemplateIds.Add(Templates.ReadResourceDataPipelineStep.TemplateId);
              }
      
              protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
              {
                  base.AddEndpointSettings(source, pipelineStep);
                  base.AddResourceSettings(source, pipelineStep);
                  base.AddReadResourceDataSettings(source, pipelineStep);
              }
          }
      }

   .. important:: 

       See Tip and Note from :doc:`../implement-tenant-settings/index` for more information about ``templates.cs``.

