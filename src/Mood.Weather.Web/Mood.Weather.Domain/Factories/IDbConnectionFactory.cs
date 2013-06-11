using System;
using System.Collections.Generic;
using System.Data;

namespace Mood.Weather.Domain.Factories
{
    /// <summary>
    /// Generic interface used to build a connection
    /// </summary>
    public interface IDbConnectionFactory 
    {
        IDbConnection Create();
    }
}
