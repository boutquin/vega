namespace Vega.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Model : SelfTracking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        // A Model belongs to a single Male.
        public int MakeId { get; set; }
        public Make Make { get; set; }

        // A Model has a collection of Features
        public ICollection<ModelFeature> ModelFeatures { get; set; }
    }
}