Add Pipeline Step to Iterate Data from Source
===========================================================

The second *pipeline step* iterates the data from the response. For each object, another *pipeline* is run.

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines > Read from News API Pipeline**.
3. Add **Iterate Data and Run Pipelines Pipeline Step** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Iterate Top Headlines and Run Pipeline                                                                                               |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Pipelines**                       | * Pipelines > Article from API to Article Item Sync Pipeline                                                                         |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

4. Sort the pipeline steps in the following order:

    * Read Top Headlines
    * Iterate Top Headlines and Run Pipeline

..
    The pipeline in Content Editor.

    .. image:: _static/read-top-headlines-pipeline-finished.png

