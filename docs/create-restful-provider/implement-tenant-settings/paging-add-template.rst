Add Paging Template
=======================================

A *tenant setting* template is needed to manage paging. 

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Data Exchange > Providers > RESTful > Tenant Settings**.
3. Add the following template:

   +-------------------+---------------------------------------------------------------------------------------------+
   | Name              | **Paging**                                                                         |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base template     | **Templates > System > Templates > Standard template**                                      |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Location          | **Templates > Data Exchange > Providers > RESTful > Tenant Settings**                       |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Icon              | ``Office/32x32/navigate_right.png``                                                         |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base templates    | * **Templates > System > Templates > Standard template**                                    |
   |                   | * **Templates > Data Exchange > Framework > Common > Convertible**                          |
   +-------------------+---------------------------------------------------------------------------------------------+

4. Add the following sections and fields:

   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Section            | Name                              | Type                  | Source       | Shared     |
   +====================+===================================+=======================+==============+============+
   | Paging Settings    | **First Page Number**             | Integer               |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Page Size**                     | Integer               |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Maximum Count**                 | Integer               |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Current Page Path Expression**  | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Page Size Path Expression**     | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Total Count Path Expression**   | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+
   | Paging Settings    | **Next Token Path Expression**    | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------------+-----------------------+--------------+------------+

   .. note::
       Details about the **Path Expression** fields are available in Implement Data Access.

