namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Lacunarity { get; }
        public float Persistance { get; }
        public int Octaves { get; set; }

        public PerlinConfig(float lacunarity, float frequency, float persistance, int octaves, 
            NoiseConfig cfg
        ) : base(cfg)
        {
            Lacunarity = lacunarity;
            Frequency = frequency;
            Persistance = persistance;
            Octaves = octaves;
        }
    }
}