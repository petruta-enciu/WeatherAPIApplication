using System;
using System.Collections.Generic;

namespace Mood.Weather.Domain.Factories
{
    /// <summary>
    /// Generic interface factory used to generate publishers
    /// </summary>
    public interface ISourceFactory
    {
        ISource Create();
    }
}
