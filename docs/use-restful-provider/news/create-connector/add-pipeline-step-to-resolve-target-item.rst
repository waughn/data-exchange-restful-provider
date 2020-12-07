Add Pipline Step to Resolve Target Item
===========================================================

The first *pipeline step* determines whether or not a Sitecore item already exists for the object.

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines > Article from API to Article Item Sync Pipeline**.
3. Add **Resolve Sitecore Item Pipeline Step** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Resolve Article Item                                                                                                                 |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Template for New Item**           | Templates > Feature > Data Exchange > News API > News API Article                                                                    |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Item Name Value Accessor**        | Data Access > Value Accessor Sets > Providers > RESTful > Article Values > Title                                                     |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Endpoint From**                   | Sitecore > Sitecore Item Model Repository Endpoint                                                                                   |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Identifier Value Accessor**       | Value Accessor Sets > Providers > RESTful > Article Values > Url                                                                     |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Identifier Object Location**      | Pipeline Context Source                                                                                                              |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Resolved Object Location**        | Pipeline Context Target                                                                                                              |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Parent for Item**                 | sitecore > Content > News Articles                                                                                                   |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Matching Field Value Accessor**   | Data Access > Value Accessor Sets > Providers > Sitecore > Article Item Fields > Url                                                 |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

   .. hint:: 
       The **Identifier Object Location** field is used to determine where to find the source object.
       This value is specified in the pipeline step processor that iterates the data that is read from resource. 
       This is configured in a later step. 

..
    The pipeline in Content Editor.

    .. image:: _static/resolve-target-pipeline-step-created.png
