namespace GroanUI.Plotters
{
    public class NoiseConfig
    {
        protected NoiseConfig(NoiseConfig cfg)
        : this(cfg.Invert, cfg.MinThreshold, cfg.MaxThreshold, cfg.Round, cfg.Scale, cfg.OutputGrayscale, cfg.Seed)
        {

        }
        public NoiseConfig(bool invert,
            float minThreshold, float maxThreshold,
            bool round, 
            float scale, 
            bool grayscale, int seed)
        {
            Invert = invert;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
            Round = round;
            Scale = scale;

            OutputGrayscale = grayscale;
            Seed = seed;
        }

        public bool Invert { get; }
        public float MinThreshold { get; }
        public float MaxThreshold { get; }
        public bool Round { get; }
        public float Scale { get; }
        public bool OutputGrayscale { get;  }
        public int Seed { get;  }
    }
}