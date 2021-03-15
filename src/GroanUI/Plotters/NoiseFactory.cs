using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using GroanUI.Views.Main;

namespace GroanUI.Plotters
{
    public interface INoiseFactory
    {
        Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg);
    }

    public class NoiseFactory : INoiseFactory
    {
        public Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg)
        {
            return _noiseProvider[noiseType].GetBitmap(size, cfg);
        }

        private readonly Dictionary<NoiseType, NoiseMapMaker> _noiseProvider
            = new()
            {
                { NoiseType.Perlin, new PerlinNoiseMapMaker() },
            };


    }
}