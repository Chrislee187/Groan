namespace GroanUI
{
    public class NoiseConfig
    {
        public NoiseConfig(bool invert, float minThreshold, float maxThreshold)
        {
            Invert = invert;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }

        public bool Invert { get; }
        public float MinThreshold { get; }
        public float MaxThreshold { get; }
    }

    public class PerlinConfig : NoiseConfig
    {
        public int Scale { get; }
        public PerlinConfig(bool invert, float minThreshold, float maxThreshold,
            int scale) : base(invert, minThreshold, maxThreshold)
        {
            Scale = scale < 1 ? 1 : scale;
        }
    }
}