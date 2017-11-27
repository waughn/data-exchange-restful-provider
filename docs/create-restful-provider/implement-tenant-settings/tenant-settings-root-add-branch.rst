Add Tenant Settings Root Branch
=======================================

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches**.
3. Add the following branch:

   +-------------------+--------------------------------------------------------------------------------------------------+
   | Name              | **RESTful Tenant Settings Root**                                                                 |
   +-------------------+--------------------------------------------------------------------------------------------------+
   | Base template     | **Templates > System > Branches > Branch Folder**                                                |
   +-------------------+--------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches**                        |
   +-------------------+--------------------------------------------------------------------------------------------------+

4. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > $name**.
5. Rename $name to **RESTful**.
6. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**.
7. Add the following item:

   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Name              | **Applications**                                                                                                                             |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Template          | **Templates > Data Exchange > Providers > RESTful > Folders > RESTful Tenant Settings Folders > RESTful Tenant Settings Application Root**   |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**                           |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+

8. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**.
9. Add the following item:

   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Name              | **Headers**                                                                                                                                  |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Template          | **Templates > Data Exchange > Providers > RESTful > Folders > RESTful Tenant Settings Folders > RESTful Tenant Settings Header Root**        |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**                           |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+

10. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**.
11. Add the following item:

   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Name              | **Parameters**                                                                                                                               |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Template          | **Templates > Data Exchange > Providers > RESTful > Folders > RESTful Tenant Settings Folders > RESTful Tenant Settings Parameter Root**     |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**                           |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+

12. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**.
13. Add the following item:

   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Name              | **Paging**                                                                                                                                   |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Template          | **Templates > Data Exchange > Providers > RESTful > Folders > RESTful Tenant Settings Folders > RESTful Tenant Settings Paging Root**        |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**                           |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+

14. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**.
15. Add the following item:

   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Name              | **Resources**                                                                                                                                |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Template          | **Templates > Data Exchange > Providers > RESTful > Folders > RESTful Tenant Settings Folders > RESTful Tenant Settings Resource Root**      |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+
   | Location          | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root > RESTful**                           |
   +-------------------+----------------------------------------------------------------------------------------------------------------------------------------------+

   .. image:: _static/tenant-settings-root-branch-14.png

16. Navigate to **Templates > Branches > Data Exchange > Providers > RESTful > Commands > RESTful Tenant Settings > New Item Settings**.

   .. image:: _static/tenant-settings-new-item-14.png

17. Set the following values:

   +-----------------------------+--------------------------------------------------------------------------------------------------------------+
   | Name                        | Value                                                                                                        |
   +=============================+==============================================================================================================+
   | **New Item Template**       | **Templates > Branches > Data Exchange > Providers > RESTful > Branches > RESTful Tenant Settings Root**     |
   +-----------------------------+--------------------------------------------------------------------------------------------------------------+

   .. image:: _static/tenant-settings-new-item-data-14.png

