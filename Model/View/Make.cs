namespace Vega.Model.View
{
    using System.Collections.Generic;

    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
