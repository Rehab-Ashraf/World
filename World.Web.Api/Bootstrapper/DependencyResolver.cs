

namespace World.Web.Api.Bootstrapper
{
    using Autofac;
    using AutoMapper;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using World.Data.EF.Context;
    using World.Data.Repository.CityRepositories;
    using World.Data.Repository.CountryRepositories;
    using World.Services.CityServices;
    using World.Services.CountryServices;

    public class DependencyResolver : Module
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; set; }
        public DependencyResolver(IWebHostEnvironment env)
        {
            _env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true);

            Configuration = configBuilder.Build();
            LoadModules(builder);
        }

        private void LoadModules(ContainerBuilder builder)
        {
            LoadDbContexts(builder);
            LoadCountries(builder);
            LoadCities(builder);
            LoadMappers(builder);
        }
        private void LoadMappers(ContainerBuilder builder)
        {
            var mapperConfig = AutoMapperConfig.Initialize();

            builder.Register(c => AutoMapperConfig.Initialize()).AsSelf().SingleInstance();
            builder.Register(context => context.Resolve<MapperConfiguration>()
            .CreateMapper(context.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

        }

        private void LoadCountries(ContainerBuilder builder)
        {
            //register service
            builder.RegisterType<CountryService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //register repository
            builder.RegisterType<CountryRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void LoadCities(ContainerBuilder builder)
        {
            builder.RegisterType<CityService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CityRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
        private void LoadDbContexts(ContainerBuilder builder)
        {
            builder.RegisterType<WorldDbContext>().InstancePerLifetimeScope();
        }
    }
}
