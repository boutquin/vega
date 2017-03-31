namespace Vega.Services
{
    using System.Collections.Generic;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using Vega.Data;

    public class VegaRepository : IVegaRepository
    {
        private readonly VegaContext context;
        private readonly IMapper mapper;
        public VegaRepository(VegaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<Vega.Model.View.Feature> GetFeatures()
        {
            var features = this.context.Features;

            return features == null 
                ? null 
                : this.mapper.Map<IEnumerable<Feature>, IEnumerable<Vega.Model.View.Feature>>(features);
        }

        public IEnumerable<Vega.Model.View.Make> GetMakes()
        {
            var makes = this.context.Makes
                .Include(m => m.Models);

            return makes == null
                ? null
                : this.mapper.Map<IEnumerable<Make>, IEnumerable<Vega.Model.View.Make>>(makes);
        }
    }
}