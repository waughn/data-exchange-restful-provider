Configure Sitecore Connect for News API 
===========================================================



1. Follow steps from :doc:`../install-connector/index`.
2. Register at `newsapi.org <https://newsapi.org>`_ to get an API key, and select source from `news source <https://newsapi.org/sources>`_.
3. In Sitecore, open **Content Editor**.
4. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Headers > X-Api-Key**.
5. Enter *API key* in **Header Value** field. 
6. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Tenant Settings > RESTful > Parameters > Sources**.
7. Enter *source* in **Parameter Value** field. 
8. Navigate to **sitecore > system > Data Exchange > Data Exchange Tenant for News API > Pipeline Batches > Top Headlines Sync Pipeline Batch**.
9. On the **Data Exchange** tab in the ribbon, click **Run Pipeline Batch**.
10. Navigate to **sitecore > content > News Articles** to view imported items.
