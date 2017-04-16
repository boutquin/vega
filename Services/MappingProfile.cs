namespace Vega.Services
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Data.Feature, Model.View.Feature>();
            this.CreateMap<Data.Make, Model.View.Make>();
            this.CreateMap<Data.Model, Model.View.Model>()
                .ForMember(
                    dest => dest.Features,
                    opt => opt.MapFrom(src => src.ModelFeatures));
            this.CreateMap<Data.ModelFeature, Model.View.Feature>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Feature.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Feature.Name)
                );
        }
    }
}
