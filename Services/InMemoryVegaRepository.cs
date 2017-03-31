using System.Collections.Generic;

namespace Vega.Services
{
    using Vega.Model.View;
    public class InMemoryVegaRepository : IVegaRepository
    {
        public IEnumerable<Make> GetMakes()
        {
            return new List<Make>
                {
                    new Make
                        {
                            Id = 1,
                            Name = "Make 1",
                            Models = new List<Model>
                                {
                                    new Model { Id = 1, Name = "Model1" },
                                    new Model { Id = 2, Name = "Model2" }
                                }
                        }
                };
        }

        public IEnumerable<Feature> GetFeatures()
        {
            return new List<Feature>
                {
                    new Feature { Id = 1, Name = "Feature1" },
                    new Feature { Id = 2, Name = "Feature2" }
                };
        }
    }
}
