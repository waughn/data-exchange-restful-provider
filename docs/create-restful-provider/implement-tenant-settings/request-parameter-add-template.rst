Add Request Parameter Template
=======================================

A *tenant setting* template is needed to manage request parameters. 

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Data Exchange > Providers > RESTful > Tenant Settings**.
3. Add the following template:

   +-------------------+---------------------------------------------------------------------------------------------+
   | Name              | **Request Parameter**                                                                       |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base template     | **Templates > System > Templates > Standard template**                                      |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Location          | **Templates > Data Exchange > Providers > RESTful > Tenant Settings**                       |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Icon              | ``Office/32x32/html_tag.png``                                                               |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base templates    | * **Templates > System > Templates > Standard template**                                    |
   |                   | * **Templates > Data Exchange > Framework > Common > Convertible**                          |
   +-------------------+---------------------------------------------------------------------------------------------+

4. Add the following sections and fields:

   +--------------------+-----------------------------+-----------------------+--------------+------------+
   | Section            | Name                        | Type                  | Source       | Shared     |
   +====================+=============================+=======================+==============+============+
   | Parameter          | **Parameter Token**         | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------+-----------------------+--------------+------------+
   | Parameter          | **Parameter Value**         | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------+-----------------------+--------------+------------+


