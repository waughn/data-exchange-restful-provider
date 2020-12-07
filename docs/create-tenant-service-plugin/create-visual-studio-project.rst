Create Visual Studio Project
=======================================

A Visual Studio project is needed to initialize plugins for Data Exchange Framework Tenant Service.

**Data Exchange Framework Tenant Service 5.0.0**

1. In Visual Studio, create project with the following settings:

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.RESTful.Web**    |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.8.0 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

2. Add references to the project:

   +--------------------------------------------+
   | **Projects**                               |
   +--------------------------------------------+
   | DataExchange.Providers.RESTful             |
   +--------------------------------------------+

3. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.AspNet.WebApi.WebHost" Version="5.2.6" />``                    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="2.1.1" />``    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="2.1.1" />``           |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange" Version="5.0.0" />``                              |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Web" Version="5.0.0" />`` [1]_                     |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+

4. Create the another project with the following settings:

   .. note::
       The initialization of SitecoreItemUtilities plugin is missing for the Sitecore Provider for Tenant Service.

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.Sc.Web**         |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.8.0 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

5. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Providers.Sc" Version="5.0.0" />``                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+


**Data Exchange Framework Tenant Service 4.0.0**

1. In Visual Studio, create project with the following settings:

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.RESTful.Web**    |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

2. Add references to the project:

   +--------------------------------------------+
   | **Projects**                               |
   +--------------------------------------------+
   | DataExchange.Providers.RESTful             |
   +--------------------------------------------+

3. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.AspNet.WebApi.WebHost" Version="5.2.6" />``                    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="2.1.1" />``    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="2.1.1" />``           |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange" Version="4.0.0" />``                              |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Web" Version="4.0.0" />`` [1]_                     |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+

4. Create the another project with the following settings:

   .. note::
       The initialization of SitecoreItemUtilities plugin is missing for the Sitecore Provider for Tenant Service.

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.Sc.Web**         |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

5. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Providers.Sc" Version="4.0.0" />``                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+


**Data Exchange Framework Tenant Service 3.0.1**

1. In Visual Studio, create project with the following settings:

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.RESTful.Web**    |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

2. Add references to the project:

   +--------------------------------------------+
   | **Projects**                               |
   +--------------------------------------------+
   | DataExchange.Providers.RESTful             |
   +--------------------------------------------+

3. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.AspNet.WebApi.WebHost" Version="5.2.6" />``                    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="2.1.1" />``    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="2.1.1" />``           |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange" Version="3.0.1" />``                              |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Web" Version="3.0.0" />`` [1]_                     |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+

4. Create the another project with the following settings:

   .. note::
       The initialization of SitecoreItemUtilities plugin is missing for the Sitecore Provider for Tenant Service.

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.Sc.Web**         |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

5. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Providers.Sc" Version="3.0.1" />``                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+


**v2.1.0**

1. In Visual Studio, create project with the following settings:

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.RESTful.Web**    |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

2. Add references to the project:

   +--------------------------------------------+
   | **Projects**                               |
   +--------------------------------------------+
   | DataExchange.Providers.RESTful             |
   +--------------------------------------------+

3. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.AspNet.WebApi.WebHost" Version="5.2.6" />``                    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="2.1.1" />``    |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="2.1.1" />``           |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange" Version="2.1.0" />``                              |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Web" Version="2.1.0" />`` [1]_                     |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+

4. Create the another project with the following settings:

   .. note::
       The initialization of SitecoreItemUtilities plugin is missing for the Sitecore Provider for Tenant Service.

   +-------------------------------+-------------------------------------------+
   | Template                      | **Class Library**                         |
   +-------------------------------+-------------------------------------------+
   | Name                          | **DataExchange.Providers.Sc.Web**         |
   +-------------------------------+-------------------------------------------+
   | .NET Framework version        | **4.7.1 (or higher)**                     |
   +-------------------------------+-------------------------------------------+

5. Add the following package references to the project:

   +-------------------------------------------------------------------------------------------------------+
   | **Package Reference**                                                                                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Serilog" Version="2.6.0" />``                                            |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="Sitecore.DataExchange.Providers.Sc" Version="2.1.0" />``                 |
   +-------------------------------------------------------------------------------------------------------+
   | ``<PackageReference Include="WebActivatorEx" Version="2.2.0" />``                                     |
   +-------------------------------------------------------------------------------------------------------+



.. [1] The Sitecore.DataExchange.Web package is currently not available on the `Official Sitecore NuGet Feed <https://sitecore.myget.org/gallery/sc-packages>`_.
       Reference the Sitecore.DataExchange.Web.dll in the Data Exchange Framework Tenant Web Service web deployment package or the Tenant Web Service bin folder.
