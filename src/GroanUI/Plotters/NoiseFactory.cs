using System.Collections.Generic;
using System.Drawing;
using GroanUI.Views.Main;

namespace GroanUI.Plotters
{
    public class NoiseFactory : INoiseFactory
    {
        public string Info { get; private set; }
        public Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg)
        {
            var b = _noiseProvider[noiseType];
            var noiseBitmap = b.GetBitmap(size, cfg);
            Info = $"Density: {b.Density:P}, Coverage: {b.Coverage:P}";
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
        public string Info { get; }
        Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, NoiseConfig cfg);
    }
}