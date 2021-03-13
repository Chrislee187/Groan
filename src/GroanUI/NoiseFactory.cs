using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace GroanUI
{
    public interface INoiseFactory
    {
        Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg);
    }

    public class NoiseFactory : INoiseFactory
    {
        public Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg)
        {
            var bmp = new Bitmap(
                size.Width,
                size.Height,
                PixelFormat.Format32bppRgb);

            var noise = _noiseProvider[noiseType];

            noise.Plot(bmp, cfg);

            return bmp;
        }

        private readonly Dictionary<NoiseType, NoisePlotter> _noiseProvider
            = new()
            {
                { NoiseType.HorizontalGradient, new HGradientPlotter() },
                { NoiseType.VerticalGradient, new VGradientPlotter() },
                { NoiseType.Random, new SystemRandomPlotter() },
                { NoiseType.Perlin, new PerlinPlotter() },
            };


    }
}