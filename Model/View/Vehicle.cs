﻿namespace Vega.Model.View
{
    using System.Collections.Generic;

    public class Vehicle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsRegistered { get; set; }

        // A Vehicle corresponds to a single Model.
        public Model Model { get; set; }

        public Contact Contact { get; set; }

        // A Vehicle has a collection of Features
        public ICollection<Feature> Features { get; set; }
    }
}
