Add Endpoint for Source
===========================================================

An *endpoint* is needed to identify the application to use during synchronization process.

1. In Sitecore, open Content Editor.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Endpoints > Providers**.
3. Add **RESTful Endpoints**.

    .. hint:: 
        This template is a command template. It does not prompt for the 
        item name. The command template assigns the item name automatically.

    ..
        The new endpoints folder in Content Editor.

        .. image:: _static/restful-endpoints-folder.png

4. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Endpoints > Providers > RESTful**.
5. Add **RESTful Endpoint** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                                |
   +=============================+======================================================================================================================================+
   | **Name**                    | News API Endpoint                                                                                                                    |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Application**             | * **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Applications > News API**    |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

    ..
        The new endpoint in Content Editor.

        .. image:: _static/restful-endpoint.png
