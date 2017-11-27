Create Sitecore Connect for News API 
===========================================================

The section covers steps to create a connector for `News API <https://newsapi.org>`_. 
The synchronization process will read news articles from the service, and create Sitecore
items for each article returned. 

.. toctree::
    :name: use-the-provider-create-steps
    :caption: Steps
    :numbered:
    :maxdepth: 1
    :titlesonly:

    get-news-api-key
    create-template-for-target
    add-folder-for-sitecore-items
    add-tenant
    add-tenant-settings
    add-endpoint-for-source
    add-endpoint-for-target
    add-value-accessor-set-for-source
    add-value-accessor-set-for-target
    add-value-mapping-set
    add-pipeline-to-sync-single-object-from-source
    add-pipeline-step-to-resolve-target-item
    add-pipeline-step-to-apply-mapping
    add-pipeline-step-to-update-sitecore-item
    add-pipeline-to-read-source
    add-pipeline-step-to-read-from-source
    add-pipeline-step-to-iterate-data-from-source
    add-pipeline-batch
    test-pipeline-batch

