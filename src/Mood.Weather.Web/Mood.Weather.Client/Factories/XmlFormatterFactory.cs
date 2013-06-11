using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace Mood.Weather.Client.Factories
{
    /// <summary>
    /// Implement a XML MediaTypeFormatter factory
    /// </summary>
    public class XmlFormatterFactory : IMediaTypeFormatterFactory
    {
        /// <summary>
        /// Creates a XmlFormatterFactory
        /// </summary>
        /// <returns>
        /// XmlFormatterFactory
        /// </returns>
        IMediaTypeFormatterFactory IMediaTypeFormatterFactory.Create()
        {
            return new XmlFormatterFactory();
        }

        /// <summary>
        /// Creates an XmlMediaTypeFormatter with default settings
        /// </summary>
        /// <returns>
        /// XmlMediaTypeFormatter
        /// </returns>
        MediaTypeFormatter IMediaTypeFormatterFactory.Formatter()
        {
            return new XmlMediaTypeFormatter()
                            {
                                UseXmlSerializer = true
                            };
        }

  
    }
}
