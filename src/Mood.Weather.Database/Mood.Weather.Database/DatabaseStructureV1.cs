using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Mood.Weather.Database
{
    [Migration(1)]
    public class DatabaseStructureV1 : Migration
    {
        public override void Up()
        {
            Execute.Script("weather_v1.sql");
        }

        public override void Down()
        {
        }
    }
}
