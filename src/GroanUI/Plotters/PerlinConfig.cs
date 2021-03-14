namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public int Scale { get; }
        public float Amplitude { get; }
        public float Frequency { get; }
        public int XOffset { get; }
        public int YOffset { get; }

        public PerlinConfig(bool invert, float minThreshold, float maxThreshold, bool oneBit,
            int scale,
            float amplitude, float frequency,
            int xOffset, int yOffset
        ) : base(invert, minThreshold, maxThreshold, oneBit)
        {
            Scale = scale < 1 ? 1 : scale;
            Amplitude = amplitude;
            Frequency = frequency;
            XOffset = xOffset;
            YOffset = yOffset;
        }
    }
}