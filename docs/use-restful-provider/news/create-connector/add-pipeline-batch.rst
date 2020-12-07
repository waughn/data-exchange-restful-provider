Add Pipeline Batch
===========================================================

A *pipeline batch* is used to run *pipelines*. 

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipeline Batches**.
3. Add **Pipeline Batch** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Top Headlines Sync Pipeline Batch                                                                                                    |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Pipelines**                       | * Pipelines > Read from News API Pipeline                                                                                            |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

..
   The pipeline batch in Content Editor.

   .. image:: _static/pipeline-batch-created.png
