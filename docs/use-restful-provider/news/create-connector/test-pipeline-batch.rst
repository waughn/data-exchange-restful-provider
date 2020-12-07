Test Pipeline Batch
===========================================================

The *pipeline batch* is ready to run.

1. In Content Editor, navigate to your *tenant*.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipeline Batches > Top Headlines Sync Pipeline Batch**.
3. In the Content Editor ribbon, click **Run Pipeline Batch**.

    ..
        .. image:: _static/run-pipeline-batch-button.png
 
4. Click **OK**.

    ..
        .. image:: _static/pipeline-batch-started.png

In the pipeline batch summary you should see messages like the following: 

.. code-block:: none

    INFO	Pipeline step reading data. (pipeline step: Read Top Headlines, plugin: Sitecore.DataExchange.Plugins.EndpointSettings)
    WARN	No access token is specified on the endpoint (pipeline step: Read Top Headlines, endpoint: News API Endpoint)
    INFO	10 rows were read from endpoint. (pipeline step: Read Top Headlines, endpoint: News API Endpoint)
    INFO	10 total rows were read from endpoint. (pipeline step: Read Top Headlines, endpoint: News API Endpoint)
    INFO	Pipeline context has data? True (pipeline step: Read Top Headlines, plugin: Sitecore.DataExchange.Plugins.EndpointSettings)
    INFO	10 elements were iterated. (pipeline: Read from News API Pipeline, pipeline step: Iterate Top Headlines and Run Pipeline)

In Content Editor, under **sitecore > Content > News Articles**, you should see 10 items.

..
    .. image:: _static/target-items-created.png

Each news article item should have its fields populated. 
