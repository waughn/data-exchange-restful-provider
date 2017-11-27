Add Endpoint for Target
===========================================================

An *endpoint* is needed to identify the Sitecore database within the
synchronization process.

1. In Sitecore, open Content Editor.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Endpoints > Providers**.
3. Add **Sitecore Endpoints Root**.

    .. hint:: 
        This template is a command template. It does not prompt for the 
        item name. The command template assigns the item name automatically.

   The new endpoints folder in Content Editor.

   .. image:: _static/sitecore-endpoints-folder.png

4. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Endpoints > Providers > Sitecore**.
5. Add **Sitecore Item Model Repository Endpoint** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                                |
   +=============================+======================================================================================================================================+
   | **Name**                    | Sitecore Item Model Repository Endpoint                                                                                              |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

   The new endpoint in Content Editor.

   .. image:: _static/sitecore-database-endpoint.png
