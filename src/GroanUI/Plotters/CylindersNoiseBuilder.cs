using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class CylindersNoiseBuilder : NoiseBuilder
    {
        protected override Module BuildNoiseSource(NoiseConfig cfg)
        {
            var pcfg = (CylinderConfig)cfg;
            var noiseSource = new SharpNoise.Modules.Cylinders()
            {
                Frequency = pcfg.Frequency,
            };
            return noiseSource;
        }
    }
}