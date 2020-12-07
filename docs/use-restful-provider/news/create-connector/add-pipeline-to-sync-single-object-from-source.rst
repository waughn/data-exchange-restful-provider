Add Pipeline to Sync Single Object from Source
===========================================================

The synchronization process consists of two *pipelines*. The first pipeline reads data from a *source* object, 
a response from a RESTful Web service. The second pipeline handles a single object from the response.

The the first pipeline calls the second pipeline so the second pipeline needs to be configured first.

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines**.
3. Add **Pipeline** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                                |
   +=============================+======================================================================================================================================+
   | **Name**                    | Article from API to Article Item Sync Pipeline                                                                                       |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

..
   The pipeline in Content Editor.

   .. image:: _static/single-object-pipeline-created.png
