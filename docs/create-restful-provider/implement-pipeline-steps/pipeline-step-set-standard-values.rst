Set Read Pipeline Data Step Standard Values
=================================================

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Data Exchange > Providers > RESTful > Pipeline Steps > Read Resource Data Pipeline Step**.
3. Add Standard Values item.
4. Navigate to Standard Values item.
5. Set the following values:

   **v2.0 or later**

   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                                                          |
   +=============================+================================================================================================================================================================+
   | **Troubleshooter Type**     | DataExchange.Providers.RESTful.Troubleshooters.PipelineSteps.ReadResourceDataTroubleshooter, DataExchange.Providers.RESTful, DataExchange.Providers.RESTful    |
   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
   | **Converter Type**          | DataExchange.Providers.RESTful.Converters.PipelineSteps.ReadResourceDataStepConverter, DataExchange.Providers.RESTful                                          |
   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
   | **Processor Type**          | DataExchange.Providers.RESTful.Processors.PipelineSteps.ReadResourceDataPipelineStep, DataExchange.Providers.RESTful                                           |
   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+

   **v1.4.1 or earlier**

   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                                                          |
   +=============================+================================================================================================================================================================+
   | **Converter Type**          | DataExchange.Providers.RESTful.Converters.PipelineSteps.ReadResourceDataStepConverter, DataExchange.Providers.RESTful                                          |
   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
   | **Processor Type**          | DataExchange.Providers.RESTful.Processors.PipelineSteps.ReadResourceDataPipelineStep, DataExchange.Providers.RESTful                                           |
   +-----------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------------------+
