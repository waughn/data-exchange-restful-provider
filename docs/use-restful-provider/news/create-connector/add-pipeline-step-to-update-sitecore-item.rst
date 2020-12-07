Add Pipeline Step to Update Sitecore Item
===========================================================

The *target* object represents a Sitecore item, but a *pipeline step* must be configured in order to update the Sitecore item.

1. In Content Editor, navigate to your tenant.

2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines > Article from API to Article Item Sync Pipeline**.

3. Add **Update Sitecore Item Pipeline Step** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Update Sitecore Item                                                                                                                 |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Endpoint To**                     | Sitecore > Sitecore Item Model Repository Endpoint                                                                                   |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

4. Sort the pipeline steps in the following order:

    * Resolve Article Item
    * Apply Mapping
    * Update Sitecore Item

..
    The pipeline in Content Editor.

    .. image:: _static/single-object-pipeline-finished.png
