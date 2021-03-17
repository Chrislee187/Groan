using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class PerlinNoiseBuilder : NoiseBuilder
    {
        protected override Module BuildNoiseSource(NoiseConfig cfg)
        {
            var pcfg = (PerlinConfig) cfg;
            var noiseSource = new Perlin
            {
                Seed = pcfg.Seed,
                Frequency = pcfg.Frequency, 
                Lacunarity = pcfg.Lacunarity, 
                Persistence = pcfg.Persistance, 
                OctaveCount = pcfg.Octaves,
                // TODO: Front end for
                Quality = pcfg.Quality
            };
            return noiseSource;
        }
    }
}