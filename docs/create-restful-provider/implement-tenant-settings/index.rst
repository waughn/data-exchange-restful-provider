Implement Tenant Settings
=======================================

This section covers how to implement *tenant settings* that can 
be used to configure other *tenant settings*, *pipeline steps* and *endpoints*.

.. tip::
    Install `Dynamics CRM Connect <https://dev.sitecore.net/Downloads/Dynamics_CRM_Connect>`_
    and view how *tenent settings* are used in a provider and connector.

.. tip::
    Use a **code generator** to create structs for template names and IDs, and field names and IDs
    to use in *converters* and *pipeline steps*. When template and field names are changed in Sitecore, 
    the generated values are kept in-sync and compiler errors are generated when values are changed 
    and not updated in *converters* and *pipeline steps*.

.. toctree::
    :name: implement-tenant-settings-steps
    :caption: Steps
    :maxdepth: 1
    :titlesonly:

    tenant-settings-add-folder
    request-header-add-template
    request-header-implement-plugin-and-converter
    request-header-set-standard-values
    request-parameter-add-template
    request-parameter-implement-plugin-and-converter
    request-parameter-set-standard-values
    paging-add-template
    paging-implement-plugin-and-converter
    paging-set-standard-values
    resource-add-template
    resource-implement-plugin-and-converter
    resource-set-standard-values
    application-add-template
    application-implement-plugin-and-converter
    application-set-standard-values
    tenant-settings-root-add-folders
    tenant-settings-root-add-branch

.. _implement_tenant_settings_tip:

.. note::
    A **code generator** is used to create the ``templates.cs`` file; however, steps are not included to configure
    this process. The following code block is a sample of the generated code:

    .. code-block:: c#

        namespace DataExchange.Providers.RESTful
        {
            using System;
        
            public partial struct Templates
            {
        
                /// <summary>
                /// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Request Header
                /// </summary>
                public partial struct RequestHeader
                {
                    public static readonly Guid TemplateId = Guid.Parse("{EDF0DCDD-E7EC-4B51-86D6-5BC7218ABDEB}");
                    public const string TemplateName = "Request Header";
                    
                    public partial struct FieldIDs
                    {
                        public static readonly Guid HeaderName = Guid.Parse("{835BC979-A99D-4DB5-B9CF-3283C604259B}");
                        public static readonly Guid HeaderValue = Guid.Parse("{851F32FD-0886-4EB8-A044-D8928C07AA7D}");
                    }
        
                    public partial struct FieldNames
                    {
                        public const string HeaderName = "Header Name";
                        public const string HeaderValue = "Header Value";
                    }
                }
            }
        }