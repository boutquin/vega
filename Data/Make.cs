namespace Vega.Data
{
    using System.Collections.Generic;

    public class Make : SelfTracking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // A Make has a collecton of Models
        public ICollection<Model> Models { get; set; }
    }
}
