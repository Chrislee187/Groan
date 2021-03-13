namespace GroanUI
{
    public class PerlinConfig : NoiseConfig
    {
        public int Scale { get; }
        public float Amplitude { get; set; }
        public float Frequency { get; set; }

        public PerlinConfig(bool invert, float minThreshold, float maxThreshold, bool oneBit,
            int scale,
            float amplitude, float frequency
        ) : base(invert, minThreshold, maxThreshold, oneBit)
        {
            Scale = scale < 1 ? 1 : scale;
            Amplitude = amplitude;
            Frequency = frequency;
        }
    }
}