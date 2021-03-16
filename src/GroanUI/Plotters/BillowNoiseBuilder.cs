using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class BillowNoiseBuilder : NoiseBuilder
    {
        protected override Module BuildNoiseSource(NoiseConfig cfg)
        {
            var pcfg = (PerlinConfig)cfg;
            var noiseSource = new SharpNoise.Modules.Billow()
            {
                Seed = pcfg.Seed,
                Frequency = pcfg.Frequency,
                Lacunarity = pcfg.Lacunarity,
                Persistence = pcfg.Persistance,
                OctaveCount = pcfg.Octaves,
                // TODO: Front end for
                Quality = NoiseQuality.Standard
            };
            return noiseSource;
        }
    }
}