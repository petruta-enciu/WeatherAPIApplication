using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood.Weather.Domain.Factories
{   
    /// <summary>
    ///  Generic interface used to get weather
    /// </summary>
    public interface ISource
    {
        Uri Location { get; set; }
        Uri BuildCall(object[] queryParams);
    }
}
