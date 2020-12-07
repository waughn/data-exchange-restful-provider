Add Pipeline Step to Read from Source
===========================================================

The first *pipeline step* processes the response configured in the *endpoint* and resource settings.

.. note::
    Refer to the sample response below while configuring the *pipeline step*.

    .. code-block:: json

        {
          "status": "ok",
          "articles": [
            {
              "source": {
                "id": "lorem",
                "name": "Lorem"
              },
              "author": "Lorem Ipsum",
              "title": "Aliquam volutpat elit turpis, et rhoncus sapien maximus quis",
              "description": "Aliquam lacus velit, eleifend quis leo vitae, condimentum cursus nisi.",
              "url": "https://www.lipsum.com/feed/html",
              "urlToImage": "http://via.placeholder.com/350x150",
              "publishedAt": "2017-11-01T00:00:00Z"
            }
          ]
        }

1. In Content Editor, navigate to your tenant.
2. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipelines > Read from News API Pipeline**.
3. Add **Read Resource Data Pipeline Step** with the following field values:

   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | Name                                | Value                                                                                                                                |
   +=====================================+======================================================================================================================================+
   | **Name**                            | Read Top Headlines                                                                                                                   |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Endpoint From**                   | RESTful > News API Endpoint                                                                                                          |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Resource**                        | Resource > Top Headlines                                                                                                             |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+
   | **Path Expression**                 | articles                                                                                                                             |
   +-------------------------------------+--------------------------------------------------------------------------------------------------------------------------------------+

   .. important::
        The *Path Expression* is the property name that contains the array of items.

..
  The pipeline in Content Editor.

  .. image:: _static/read-top-headlines-pipeline-step-created.png
