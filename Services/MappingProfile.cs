namespace Vega.Services
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Data.Feature, Model.View.Feature>();
            this.CreateMap<Data.Make, Model.View.Make>();
            this.CreateMap<Data.Model, Model.View.Model>();
        }
    }
}
