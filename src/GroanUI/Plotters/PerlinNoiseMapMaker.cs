using System.Drawing;
using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class PerlinNoiseMapMaker : NoiseMapMaker
    {

        protected override NoiseMap BuildNoise(Size size, NoiseConfig cfg)
        {
            var pcfg = cfg as PerlinConfig;
            var noiseSource = new Perlin
            {
                Seed = 0 //new Random().Next()
                , Frequency = pcfg.Frequency
                , Lacunarity = pcfg.Lacunarity
                // TODO: Front end for
                // , Persistence = pcfg.Persistance
                // , OctaveCount = pcfg.OctaveCount
                , Quality = NoiseQuality.Standard
            };
            
            var noiseMap = new NoiseMap(size.Width, size.Height);
            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource, 
                EnableSeamless = true
            };
            
            noiseMapBuilder.SetDestSize(noiseMap.Width, noiseMap.Height);
            noiseMapBuilder.SetBounds(-3, 3, -2, 2);
            noiseMapBuilder.Build();


            return noiseMap;
        }
        
        public override void Plot(Bitmap b, NoiseConfig cfg)
        {

        }
        protected override float PlotValue(int x, int y, Size size, NoiseConfig cfg)
        {
            return 0;
        }
    }
}