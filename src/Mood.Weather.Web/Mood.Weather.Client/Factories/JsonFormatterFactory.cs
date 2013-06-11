using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Mood.Weather.Client.Factories
{
    /// <summary>
    /// Implement a Json MediaTypeFormatter factory
    /// </summary>
    public class JsonFormatterFactory : IMediaTypeFormatterFactory
    {
        /// <summary>
        /// Creates an JsonFormatterFactory object
        /// </summary>
        /// <returns>
        /// JsonFormatterFactory 
        /// </returns>
        IMediaTypeFormatterFactory IMediaTypeFormatterFactory.Create()
        {
            return new JsonFormatterFactory();
        }

        /// <summary>
        /// Creates an JsonMediaTypeFormatter with default settings
        /// </summary>
        /// <returns>
        /// JsonMediaTypeFormatter
        /// </returns>
        MediaTypeFormatter IMediaTypeFormatterFactory.Formatter()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>() { new IsoDateTimeConverter() }               
            };

            return new JsonMediaTypeFormatter()
            {
                SerializerSettings = serializerSettings,                
            };
        }





 
    }
}
