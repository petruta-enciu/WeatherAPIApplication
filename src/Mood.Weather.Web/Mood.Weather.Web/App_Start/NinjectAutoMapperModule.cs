using AutoMapper;
using AutoMapper.Mappers;
using Ninject;
using Ninject.Modules;

namespace AutoMapper.Ninject
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeMapFactory>().To<TypeMapFactory>();
            Bind<Configuration>().ToConstant(new Configuration(Kernel.Get<ITypeMapFactory>(), MapperRegistry.AllMappers())).InSingletonScope();
            Bind<IConfiguration>().ToMethod(c => c.Kernel.Get<Configuration>());
            Bind<IConfigurationProvider>().ToMethod(c => c.Kernel.Get<Configuration>());
            Bind<IMappingEngine>().To<MappingEngine>();
        }
    }
}