namespace Vega.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Make : SelfTracking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        // A Make has a collecton of Models
        public ICollection<Model> Models { get; set; }
    }
}
