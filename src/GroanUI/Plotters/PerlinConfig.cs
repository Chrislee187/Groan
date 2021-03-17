using SharpNoise;

namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Lacunarity { get; }
        public float Persistance { get; }
        public int Octaves { get; }
        public NoiseQuality Quality { get; }

        public PerlinConfig(float lacunarity, float frequency, float persistance, int octaves,
            NoiseQuality quality,
            NoiseConfig cfg
        ) : base(cfg)
        {
            Lacunarity = lacunarity;
            Frequency = frequency;
            Persistance = persistance;
            Octaves = octaves;
            Quality = quality;
        }


    }
}