
namespace World.Web.Api.Country
{
    using AutoMapper;
    using World.Api.Models.Country;
    using World.Core.DomainEntities.Countries;
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            MapPostCountryInputModel();
            MapGetCountry();
        }
        private void MapPostCountryInputModel()
        {
            CreateMap<PostCountryInputModel, Country>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.ISO2, opt => opt.MapFrom(src => src.ISO2))
                  .ForMember(dest => dest.ISO3, opt => opt.MapFrom(src => src.ISO3))
                  .ForAllOtherMembers(dest => dest.Ignore());

        }

        private void MapGetCountry()
        {
            CreateMap<Country, PostCountryInputModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ISO2, opt => opt.MapFrom(src => src.ISO2))
                .ForMember(dest => dest.ISO3, opt => opt.MapFrom(src => src.ISO3))
                            .ForAllOtherMembers(dest => dest.Ignore());
            CreateMap<Country, CountryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ISO2, opt => opt.MapFrom(src => src.ISO2))
                .ForMember(dest => dest.ISO3, opt => opt.MapFrom(src => src.ISO3))
                .ForAllOtherMembers(dest => dest.Ignore());

        }
    }
}
