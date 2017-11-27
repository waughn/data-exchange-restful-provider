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