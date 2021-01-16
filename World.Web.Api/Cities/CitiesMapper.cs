using AutoMapper;


namespace World.Web.Api.Cities
{
    using World.Api.Models.City;
    using World.Core.DomainEntities.Cities;
    using World.Core.DomainEntities.Countries;
    public class CitiesMapper:Profile
    {
        public CitiesMapper()
        {
            MapPostCityInputModel();
            MapGetCityOutPutModel();
        }
        public void MapPostCityInputModel()
        {
            CreateMap<PostCityInoutModel, City>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Name_ASCII, opt => opt.MapFrom(src => src.Name_ASCII))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longtitude, opt => opt.MapFrom(src => src.Longtitude))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => Country.CreateWithId(src.CountryId)))
                .ForAllOtherMembers(dest => dest.Ignore());
        }

        public void MapGetCityOutPutModel()
        {
            CreateMap<City,PostCityInoutModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Name_ASCII, opt => opt.MapFrom(src => src.Name_ASCII))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longtitude, opt => opt.MapFrom(src => src.Longtitude))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id))
                .ForAllOtherMembers(dest => dest.Ignore());
            CreateMap<City, CityModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Name_ASCII, opt => opt.MapFrom(src => src.Name_ASCII))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longtitude , opt => opt.MapFrom(src => src.Longtitude))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id))
                .ForAllOtherMembers(dest => dest.Ignore());
        }
    }
}
