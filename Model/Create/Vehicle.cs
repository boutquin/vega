﻿namespace Vega.Model.Create
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vehicle
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsRegistered { get; set; }

        // A Vehicle corresponds to a single Model.
        public int ModelId { get; set; }

        [Required]
        public Contact Contact { get; set; }

        // A Vehicle has a collection of Features
        public ICollection<int> Features { get; set; }
    }
}
