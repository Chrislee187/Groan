using System.Collections.Generic;
using System.Drawing;
using GroanUI.Views.Main;

namespace GroanUI.Plotters
{
    public class NoiseFactory : INoiseFactory
    {
        public float Coverage { get; private set; }
        public Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg)
        {
            var noiseBitmap = _noiseProvider[noiseType].GetBitmap(size, cfg);
            Coverage = _noiseProvider[noiseType].CoveragePercent;
            return noiseBitmap;
        }

        private readonly Dictionary<NoiseType, NoiseBuilder> _noiseProvider
            = new()
            {
                { NoiseType.Perlin, new PerlinNoiseBuilder() },
                { NoiseType.Billow, new BillowNoiseBuilder() },
                { NoiseType.Cylinder, new CylindersNoiseBuilder() },
                { NoiseType.Cell, new CellNoiseBuilder() },
            };
    }

    public interface INoiseFactory
    {
        public float Coverage { get; }
        Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg);
    }
}