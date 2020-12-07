Add Pipeline Step to Apply Mappings
===========================================================

The second *pipeline step* applies the *value mapping set* configured in :doc:`add-value-mapping-set`.

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines > Article from API to Article Item Sync Pipeline**.
3. Add **Apply Mapping Pipeline Step** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Apply Mapping                                                                                                                        |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Mapping set**                     | Value Mapping Sets > Article Object to Sitecore Article Item                                                                         |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

..
   The pipeline in Content Editor.

   .. image:: _static/apply-mapping-pipeline-step-created.png
