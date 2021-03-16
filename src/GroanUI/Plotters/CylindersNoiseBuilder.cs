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
                
                //
                // Seed = pcfg.Seed,
                Frequency = pcfg.Frequency,
                // Lacunarity = pcfg.Lacunarity,
                // Persistence = pcfg.Persistance,
                // OctaveCount = pcfg.Octaves,
                // // TODO: Front end for
                // Quality = NoiseQuality.Standard
            };
            return noiseSource;
        }
    }
}