using System;
using System.Collections.Generic;

namespace Mood.Weather.Domain.Factories
{
    // describe a generic target where exported files will be saved
    /// <summary>
    /// Generic interface used generate targets
    /// </summary>
    public interface ITargetFactory
    {
        ITarget Create();
    }
}
