using System.Drawing;
using System.Numerics;

namespace GroanUI
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