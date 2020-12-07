Implement Token Value Reader 
=======================================

.. note::
    Data Exchange Framework includes a component that allows data to be read from an object. 
    See `Value Reader <http://integrationsdn.sitecore.net/DataExchangeFramework/v1.4/getting-started/mapping/value-reader.html>`_
    for more information.

1. In Visual Studio, add the following class:

   .. code-block:: c#
   
       using System;
       using Newtonsoft.Json.Linq;
       using Sitecore.DataExchange.DataAccess;
   
       namespace DataExchange.Providers.RESTful.DataAccess.Readers
       {
         public class TokenValueReader : IValueReader
         {
           public readonly string Path;
   
           public TokenValueReader(string path)
           {
             this.Path = path;
           }
   
           public bool CanRead(object source, DataAccessContext context)
           {
             if (context == null)
               throw new ArgumentNullException(nameof(context));
   
             return source is JObject;
           }
   
           public ReadResult Read(object source, DataAccessContext context)
           {
             if (!this.CanRead(source, context))
               return ReadResult.NegativeResult(DateTime.UtcNow);
   
             object value = null;
             bool wasValueRead = false;
   
             var jObject = source as JObject;
   
             if (jObject != null)
             {
               value = jObject.SelectToken(this.Path);
               wasValueRead = value != null;
             }
   
             if (!wasValueRead)
               return ReadResult.NegativeResult(DateTime.UtcNow);
   
             return ReadResult.PositiveResult(value, DateTime.UtcNow);
           }
         }
       }


   .. important:: 
       **v1.4.1 or earlier**: The ``Sitecore.DataExchange.DataAccess.CanReadResult`` class and ``CanReadResult CanRead(object source, DataAccessContext context)`` method from ``Sitecore.DataExchange.DataAccess.IValueReader`` interface were removed in Data Exchange Framework 2.0.

       .. code-block:: c#
       
           using System;
           using Newtonsoft.Json.Linq;
           using Sitecore.DataExchange.DataAccess;
           
           namespace DataExchange.Providers.RESTful.DataAccess.Readers
           {
               public class TokenValueReader : IValueReader
               {
                   public readonly string Path;
           
                   public TokenValueReader(string path)
                   {
                       this.Path = path;
                   }
           
                   public CanReadResult CanRead(object source, DataAccessContext context)
                   {
                       if (context == null)
                           throw new ArgumentNullException(nameof(context));
           
                       return new CanReadResult()
                       {
                           CanReadValue = source is JObject
                       };
                   }
           
                   public ReadResult Read(object source, DataAccessContext context)
                   {
                       if (!this.CanRead(source, context).CanReadValue)
                           return ReadResult.NegativeResult(DateTime.UtcNow);
           
                       object value = null;
                       bool wasValueRead = false;
           
                       var jObject = source as JObject;
           
                       if (jObject != null)
                       {
                           value = jObject.SelectToken(this.Path);
                           wasValueRead = value != null;
                       }
           
                       if (!wasValueRead)
                           return ReadResult.NegativeResult(DateTime.UtcNow);
           
                       return ReadResult.PositiveResult(value, DateTime.UtcNow);
                   }
               }
           }     
