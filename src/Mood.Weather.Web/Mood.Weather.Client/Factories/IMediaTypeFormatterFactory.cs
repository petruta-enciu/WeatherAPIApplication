using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace Mood.Weather.Client.Factories
{
    /// <summary>
    /// Generic interface to handle a MediaTypeFormatter
    /// </summary>
    public interface IMediaTypeFormatterFactory
    {
        IMediaTypeFormatterFactory Create();
        MediaTypeFormatter Formatter();
    }
}
