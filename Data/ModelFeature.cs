namespace Vega.Data
{
    public class ModelFeature
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}