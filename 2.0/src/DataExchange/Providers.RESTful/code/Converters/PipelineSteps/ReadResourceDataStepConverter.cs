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