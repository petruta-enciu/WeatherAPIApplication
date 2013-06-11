using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mood.Weather.Domain.Factories
{
    /// <summary>
    /// Generic interface used to define publishing process
    /// </summary>
    public interface ITarget
    {        
        bool Publish(FileStream fs);
        bool Publish(string content);
    }
}
