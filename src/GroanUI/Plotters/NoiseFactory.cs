using System.Collections.Generic;
using System.Drawing;
using GroanUI.Views.Main;

namespace GroanUI.Plotters
{
    public class NoiseFactory : INoiseFactory
    {
        public Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg)
        {
            return _noiseProvider[noiseType].GetBitmap(size, cfg);
        }

        private readonly Dictionary<NoiseType, NoiseMapMaker> _noiseProvider
            = new()
            {
                {NoiseType.Perlin, new PerlinNoiseMapMaker()},
            };
    }

    public interface INoiseFactory
    {
        Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg);
    }
}