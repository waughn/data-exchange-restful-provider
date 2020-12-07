using Sitecore.DataExchange.Models;
using DataExchange.Providers.RESTful.Plugins.Processors;
using DataExchange.Providers.RESTful.Plugins.Settings;

namespace DataExchange.Providers.RESTful.Extensions
{
    public static class PipelineStepExtensions
    {
        public static ResourceSettings GetResourceSettings(this PipelineStep pipelineStep)
        {
            return pipelineStep.GetPlugin<ResourceSettings>();
        }

        public static bool HasResourceSettings(this PipelineStep pipelineStep)
        {
            return GetResourceSettings(pipelineStep) != null;
        }

        public static ReadResourceDataSettings GetReadResourceDataSettings(this PipelineStep pipelineStep)
        {
            return pipelineStep.GetPlugin<ReadResourceDataSettings>();
        }

        public static bool HasReadResourceDataSettings(this PipelineStep pipelineStep)
        {
            return GetReadResourceDataSettings(pipelineStep) != null;
        }
    }
}
