Add Token Value Accessor Template
=======================================

`Json.NET <https://www.newtonsoft.com/json/help/html/Introduction.htm>`_ is used to query JSON with
`SelectToken  <https://www.newtonsoft.com/json/help/html/SelectToken.htm>`_. A template is needed to 
specify the token. 

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Data Exchange > Providers > RESTful > Data Access > Value Accessors**.
3. Add the following template:

   +-------------------+----------------------------------------------------------------------------------------------+
   | Name              | **Token Value Accessor**                                                                     |
   +-------------------+----------------------------------------------------------------------------------------------+
   | Base template     | **Templates > System > Templates > Standard template**                                       |
   +-------------------+----------------------------------------------------------------------------------------------+
   | Location          | **Templates > Data Exchange > Providers > RESTful > Data Access > Value Accessors**          |
   +-------------------+----------------------------------------------------------------------------------------------+
   | Icon              | ``office/32x32/radio_button_selected.png``                                                   |
   +-------------------+----------------------------------------------------------------------------------------------+
   | Base templates    | * **Templates > System > Templates > Standard template**                                     |
   |                   | * **Templates > Data Exchange > Framework > Common > Enableable**                            |
   |                   | * **Templates > Data Exchange > Framework > Data Access > Value Accessors > Value Accessor** |
   +-------------------+----------------------------------------------------------------------------------------------+

4. Add the following sections and fields:

   +--------------------+-----------------------------------+-----------------------+---------------------+------------+
   | Section            | Name                              | Type                  | Source              | Shared     |
   +====================+===================================+=======================+=====================+============+
   | Settings           | **Path Expression**               | Single-Line Text      |                     | checked    |
   +--------------------+-----------------------------------+-----------------------+---------------------+------------+
