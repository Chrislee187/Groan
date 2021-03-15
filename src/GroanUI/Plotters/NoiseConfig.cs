namespace GroanUI.Plotters
{
    public class NoiseConfig
    {
        public NoiseConfig(bool invert, 
            float minThreshold, float maxThreshold, 
            bool oneBit, float scale,
            int xOffset, int yOffset)
        {
            Invert = invert;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
            OneBit = oneBit;
            Scale = scale;
            XOffset = xOffset;
            YOffset = yOffset;
        }

        public bool Invert { get; }
        public float MinThreshold { get; }
        public float MaxThreshold { get; }
        public bool OneBit { get; }
        public float Scale { get; }
        public int XOffset { get; }
        public int YOffset { get; }


    }
}