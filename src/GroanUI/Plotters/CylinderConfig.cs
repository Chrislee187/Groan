namespace GroanUI.Plotters
{
    public class CylinderConfig : NoiseConfig
    {
        public float Frequency { get; }


        public CylinderConfig(float frequency,
            NoiseConfig cfg
        ) : base(cfg)
        {
            Frequency = frequency;
        }
    }
}