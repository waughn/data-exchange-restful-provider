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