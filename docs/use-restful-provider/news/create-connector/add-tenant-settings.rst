Add Tenant Settings
===========================================================

The following tenant settings are used to get a response from the `top headlines <https://newsapi.org/docs/endpoints/top-headlines>`_ endpoint.
Review the endpoint documentation for more information about the endpoint. 

1. In Sitecore, open Content Editor.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings**.
3. Add **RESTful Tenant Settings**.

   .. hint:: 
       This template is a command template. It does not prompt for the 
       item name. The command template assigns the item name automatically.
       
       ..
         .. image:: _static/add-tenant-settings.png

   ..
      The new tenant settings in Content Editor.

      .. image:: _static/view-tenant-settings.png

4. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Headers**.
5. Add **Request Header** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                              |
   +=============================+====================================================================================================================+
   | **Name**                    | Accept JSON                                                                                                        |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Display Name**            | Accept: application/json                                                                                           |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Header Name**             | Accept                                                                                                             |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Header Value**            | application/json                                                                                                   |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+

6. Add **Request Header** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                              |
   +=============================+====================================================================================================================+
   | **Name**                    | X-Api-Key                                                                                                          |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Header Name**             | X-Api-Key                                                                                                          |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Header Value**            | .. note::                                                                                                          |
   |                             |      Add API key created in :doc:`get-news-api-key` step.                                                          |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+

   ..
      The new request header settings in Content Editor.

      .. image:: _static/view-request-header-tenant-settings.png
    
7. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Parameters**.
8. Add **Request Parameter** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                              |
   +=============================+====================================================================================================================+
   | **Name**                    | Sources                                                                                                            |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Parameter Name**          | {sources}                                                                                                          |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Parameter Value**         | .. note::                                                                                                          |
   |                             |      Select source from `news source <https://newsapi.org/sources>`_.                                              |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+

   .. tip::
       The sources value *can* be added to the resource url; however, using parameters provide the flexibility to reuse in other settings. 

   ..
      .. image:: _static/view-request-parameter-tenant-settings.png
 
9. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Resources**.
10. Add **Resource** with the following field values:

   +-----------------------------+-------------------------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                                               |
   +=============================+=====================================================================================================================================+
   | **Name**                    | /v2/top-headlines?sources={sources}                                                                                                 |
   +-----------------------------+-------------------------------------------------------------------------------------------------------------------------------------+
   | **Method**                  | GET                                                                                                                                 |
   +-----------------------------+-------------------------------------------------------------------------------------------------------------------------------------+
   | **Headers**                 | * **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Headers > Accept JSON**     |
   |                             | * **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Headers > X-Api-Key**       |
   +-----------------------------+-------------------------------------------------------------------------------------------------------------------------------------+
   | **Parameters**              | * **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Parameters > Sources**      |
   +-----------------------------+-------------------------------------------------------------------------------------------------------------------------------------+

11. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Applications**.
12. Add **Application** with the following field values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                              |
   +=============================+====================================================================================================================+
   | **Name**                    | News API                                                                                                           |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+
   | **Base Url**                | https://newsapi.org                                                                                                |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------------+

