Add Request Header Template
=======================================

A *tenant setting* template is needed to manage request headers. 

1. In Sitecore, open Template Manager.
2. Navigate to **Templates > Data Exchange > Providers > RESTful > Tenant Settings**.
3. Add the following template:

   +-------------------+---------------------------------------------------------------------------------------------+
   | Name              | **Request Header**                                                                          |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base template     | **Templates > System > Templates > Standard template**                                      |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Location          | **Templates > Data Exchange > Providers > RESTful > Tenant Settings**                       |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Icon              | ``Office/32x32/html_tag2.png``                                                              |
   +-------------------+---------------------------------------------------------------------------------------------+
   | Base templates    | * **Templates > System > Templates > Standard template**                                    |
   |                   | * **Templates > Data Exchange > Framework > Common > Convertible**                          |
   +-------------------+---------------------------------------------------------------------------------------------+

   .. note::
       A converter is needed to convert a Sitecore item into an component for Data Exchange Framework. If custom template does not 
       inherent from a Data Exchange Framework base template, then add ``/sitecore/templates/Data Exchange/Framework/Common/Convertible``
       to base template.

4. Add the following sections and fields:

   +--------------------+-----------------------------+-----------------------+--------------+------------+
   | Section            | Name                        | Type                  | Source       | Shared     |
   +====================+=============================+=======================+==============+============+
   | Header             | **Header Name**             | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------+-----------------------+--------------+------------+
   | Header             | **Header Value**            | Single-Line Text      |              | checked    |
   +--------------------+-----------------------------+-----------------------+--------------+------------+


