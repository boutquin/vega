namespace Vega.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Feature : SelfTracking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        // A feature may be present in many Models
        public ICollection<ModelFeature> ModelFeatures { get; set; }
    }
}
