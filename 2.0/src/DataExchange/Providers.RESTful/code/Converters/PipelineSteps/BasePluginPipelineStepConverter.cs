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