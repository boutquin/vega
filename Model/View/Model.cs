namespace Vega.Model.View
{
    using System.Collections.Generic;

    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}