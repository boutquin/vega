namespace Vega.Data
{
    using System.Collections.Generic;

    public class Feature : SelfTracking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // A feature may be present in many Models
        public ICollection<ModelFeature> ModelFeatures { get; set; }
    }
}
