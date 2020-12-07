Install RESTful Provider for Tenant Service
===========================================================

.. note::

    The following steps assume that you have completed the steps from :doc:`../install-restful-provider/index` plus 
    **Data Exchange Tenant Service Tenant** for versions prior to 5.0.0.

1. Download the `Installation Guide for Data Exchange Tenant Service <https://dev.sitecore.net/Downloads/Data_Exchange_Framework/5x/Data_Exchange_Framework_500>`_

2. Follow **Install using PowerShell and Sitecore Installation Framework** steps in the **Install the web-component of Tenant Service on IIS** section.

3. Download `RESTful Provider for Tenant Service <https://github.com/waughn/data-exchange-restful-provider/releases>`_ and 
   `Sitecore Provider Plugin for Tenant Service <https://github.com/waughn/data-exchange-restful-provider/releases>`_.

4. Download `SIF plugin installation scripts for Tenant Service <https://github.com/waughn/data-exchange-restful-provider/releases>`_. It contains the following files:
    
    * ``deploy.plugin.ps1`` - a PowerShell deployment script
    * ``plugin-xp0.json`` - an installation configuration files

5. Unzip the installation script files.

6. Open a PowerShell console with administrator rights. Navigate to the folder where you unpacked the installation script files. Run the ``deploy.plugin.ps1`` script with the following syntax:

   .. code-block:: 

       .\deploy.plugin.ps1 -TenantServiceInstanceName "<tenant service instance>" -ServicePackage "<path to tenant provider.scwdp.zip file>"

   +-------------------------------+--------------------------------------------------------------+----------------------------------------------------------+
   | Parameter                     | Description                                                  |  Example                                                 |
   +===============================+==============================================================+==========================================================+
   | TenantServiceInstanceName     | The name of your Data Exchange Tenant Service instance.      | sitecore.ts	                                             |
   +-------------------------------+--------------------------------------------------------------+----------------------------------------------------------+
   | ServicePackage                | The location of the RESTful Provider for Tenant Service or   | c:\\SIF\\RESTful Provider for Tenant Service.scwdp.zip   |
   |                               | Sitecore Provider Plugin for Tenant Service package.         |                                                          |
   +-------------------------------+--------------------------------------------------------------+----------------------------------------------------------+

6. Follow **Configure a tenant service connection string** steps in the **Install the web-component of Tenant Service on IIS** section of installation guide. 

