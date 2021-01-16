
namespace World.Web.Api.Bootstrapper
{
    using AutoMapper;
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            string[] Profiles =
            {
                "World.Core.DomainEntities",
                "World.Api.Models",
                "World.Web.Api"
            };

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Profiles));
            return configuration;
        }
    }
}
