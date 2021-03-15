namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Lacunarity { get; }

        public PerlinConfig(bool invert, float minThreshold, float maxThreshold, bool oneBit, float scale,
            float lacunarity, float frequency,
            int xOffset, int yOffset
        ) : base(invert, minThreshold, maxThreshold, oneBit, scale, xOffset, yOffset)
        {
            Lacunarity = lacunarity;
            Frequency = frequency;
        }
    }
}