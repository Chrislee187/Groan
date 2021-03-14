namespace GroanUI.Plotters
{
    public class NoiseConfig
    {
        public NoiseConfig(bool invert, float minThreshold, float maxThreshold, bool oneBit)
        {
            Invert = invert;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
            OneBit = oneBit;
        }

        public bool Invert { get; }
        public float MinThreshold { get; }
        public float MaxThreshold { get; }
        public bool OneBit { get; }
    }
}