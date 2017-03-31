namespace Vega.Services
{
    using System.Collections.Generic;

    using Vega.Model.View;

    public interface IVegaRepository
    {
        IEnumerable<Feature> GetFeatures();
        IEnumerable<Make> GetMakes();
    }
}