using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions.Sql;

namespace Mood.Weather.Domain.Repository.Base
{
    public interface ISqlDialectFactory
    {
        ISqlDialect Create();
    }
}
