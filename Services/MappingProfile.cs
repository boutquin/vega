namespace Vega.Services
{
    using System.Linq;

    using AutoMapper;

    using Vega.Data;

    using Feature = Vega.Model.View.Feature;
    using Make = Vega.Model.View.Make;
    using Vehicle = Vega.Model.Create.Vehicle;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Data.Feature, Feature>();
            this.CreateMap<Data.Make, Make>();
            this.CreateMap<Data.Model, Vega.Model.View.Model>()
                .ForMember(
                    dest => dest.Features, 
                    opt => opt.MapFrom(src => src.ModelFeatures));
            this.CreateMap<Data.ModelFeature, Feature>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Feature.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Feature.Name)
                );

            this.CreateMap<Vega.Model.Create.Feature, Feature>();
            this.CreateMap<Vega.Model.Update.Feature, Feature>();
            this.CreateMap<Vehicle, Vega.Model.View.Vehicle>();
            this.CreateMap<Vega.Model.Update.Vehicle, Vega.Model.View.Vehicle>();

            //
            this.CreateMap<Vehicle, Data.Vehicle>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name))
                .ForMember(dest => dest.ContactEMail, opt => opt.MapFrom(src => src.Contact.EMail))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Contact.Phone))
                .AfterMap((vr, v) => {
                    // Remove unselected features
                    var removedFeatures = v.VehicleFeatures.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                    foreach (var f in removedFeatures)
                        v.VehicleFeatures.Remove(f);

                    // Add new features
                    var addedFeatures = vr.Features.Where(id => v.VehicleFeatures.All(f => f.FeatureId != id))
                                            .Select(id => new VehicleFeature { FeatureId = id })
                                            .ToList();
                    foreach (var f in addedFeatures)
                        v.VehicleFeatures.Add(f);
                });

            this.CreateMap<Vega.Model.Update.Vehicle, Data.Vehicle>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact.Name))
                .ForMember(dest => dest.ContactEMail, opt => opt.MapFrom(src => src.Contact.EMail))
                .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Contact.Phone))
                .AfterMap((vr, v) => {
                        // Remove unselected features
                        var removedFeatures = v.VehicleFeatures.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                        foreach (var f in removedFeatures)
                            v.VehicleFeatures.Remove(f);

                        // Add new features
                        var addedFeatures = vr.Features.Where(id => v.VehicleFeatures.All(f => f.FeatureId != id))
                            .Select(id => new VehicleFeature { FeatureId = id })
                            .ToList();
                        foreach (var f in addedFeatures)
                            v.VehicleFeatures.Add(f);
                    });

        }
    }
}
