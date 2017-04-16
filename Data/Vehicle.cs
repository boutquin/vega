namespace Vega.Data
{
    using System.Collections.Generic;

    public class Vehicle : SelfTracking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsRegistered { get; set; }

        // A Vehicle corresponds to a single Model.
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEMail { get; set; }
        // A Model has a collection of Features
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }
    }
}
