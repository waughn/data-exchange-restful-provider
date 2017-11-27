Create Provider in Sitecore
=======================================

In Sitecore, use the Data Exchange Framework SDK to create the default templates 
and items for the provider. 

1. In Sitecore, open **Content Editor**.

    .. image:: _static/content-editor-button.png

2. Right-click on the ribbon, and select **Data Exchange SDK**.

    .. image:: _static/menu-selector-arrow.png

3. On the ribbon, click the **Data Exchange SDK** tab, and click **Create Provider**.

    .. image:: _static/create-provider.png

4. Enter **RESTful** and click **OK**.

    .. image:: _static/enter-provider-name.png

5. A progress box is displayed as templates and items are created and configured. 
   The following items are created in the Sitecore database for the  provider:

    * ``/sitecore/templates/Branches/Data Exchange/Providers/RESTful``

      +--------------------------------------------+---------------------------------------------+
      | **v1.4**                                   | **v2.0**                                    |
      +--------------------------------------------+---------------------------------------------+
      | .. image:: _static/provider-branch-14.png  | .. image:: _static/provider-branch-20.png   |
      +--------------------------------------------+---------------------------------------------+

    * ``/sitecore/templates/Data Exchange/Providers/RESTful``

      +-----------------------------------------------+------------------------------------------------+
      | **v1.4**                                      | **v2.0**                                       |
      +-----------------------------------------------+------------------------------------------------+
      | .. image:: _static/provider-templates-14.png  | .. image:: _static/provider-templates-20.png   |
      +-----------------------------------------------+------------------------------------------------+

    * ``/sitecore/system/Settings/Rules/Insert Options/Rules/Data Exchange - RESTful``

      +--------------------------------------------+---------------------------------------------+
      | **v1.4**                                   | **v2.0**                                    |
      +--------------------------------------------+---------------------------------------------+
      | .. image:: _static/provider-insert-14.png  | .. image:: _static/provider-insert-20.png   |
      +--------------------------------------------+---------------------------------------------+


