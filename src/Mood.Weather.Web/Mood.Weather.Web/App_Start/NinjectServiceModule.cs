using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Mood.Weather.Domain.Repository.Base;
using Mood.Weather.Domain.Factories;
using Mood.Weather.Domain.Repository.Mapping;
using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;

namespace Mood.Weather.Web.App_Start
{
    internal class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().To<AutoMapperService>();
        }

    }
}