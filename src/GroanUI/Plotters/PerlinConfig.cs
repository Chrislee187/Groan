namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Lacunarity { get; }
        public float Persistance { get; }
        public int Octaves { get; set; }

        public PerlinConfig(bool grayscale, bool invert, float minThreshold, float maxThreshold, bool round, float scale,
            float lacunarity, float frequency, float persistance, int octaves,
            int xOffset, int yOffset
        ) : base(invert, minThreshold, maxThreshold, round, scale, xOffset, yOffset, grayscale)
        {
            Lacunarity = lacunarity;
            Frequency = frequency;
            Persistance = persistance;
            Octaves = octaves;
        }
    }
}