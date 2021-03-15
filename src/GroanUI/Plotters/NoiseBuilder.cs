using System;
using System.Drawing;
using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;
using SharpNoise.Utilities.Imaging;
using Color = System.Drawing.Color;

namespace GroanUI.Plotters
{
    public abstract class NoiseBuilder
    {
        protected abstract Module BuildNoiseSource(NoiseConfig cfg);

        protected virtual NoiseMap BuildNoiseMap(Size size, NoiseConfig cfg)
        {
            var noiseSource = BuildNoiseSource(cfg);

            var noiseMap = new NoiseMap(size.Width, size.Height);

            Console.WriteLine(noiseMap[1,1]);

            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource,
                EnableSeamless = true
            };

            noiseMapBuilder.SetDestSize(noiseMap.Width, noiseMap.Height);
            // noiseMapBuilder.SetBounds(-3, 3, -2, 2);
            noiseMapBuilder.SetBounds(0, 1, 0, 1);
            noiseMapBuilder.Build();

            return noiseMap;
        }
        public virtual double[,] GetMap(Size size, NoiseConfig cfg)
        {
            var pcfg = cfg as PerlinConfig;
            var noise = BuildNoiseMap(size, pcfg);
            var map = ToArray(size, noise);
            return map;
        }
        public virtual NoiseMap GetNoiseMap(Size size, NoiseConfig cfg)
        {
            return BuildNoiseMap(size, cfg as PerlinConfig);
        }

        public virtual Bitmap GetBitmap(Size size, NoiseConfig cfg)
        {
            var map = GetNoiseMap(size, cfg);
            if (map.IsEmpty) return new Bitmap(1, 1);
            return CreateBitmap(size, map, cfg);
        }
        
        protected static Bitmap CreateBitmap(Size size, NoiseMap map, NoiseConfig cfg)
        {
            var image = new SharpNoise.Utilities.Imaging.Image(size.Width, size.Height);
            var renderer = new ImageRenderer
            {
                SourceNoiseMap = map,
                DestinationImage = image
            };
            if (cfg.OutputGrayscale)
            {
                renderer.BuildGrayscaleGradient();
            }
            else
            {
                renderer.BuildTerrainGradient();
            }

            renderer.Render();

            return image.ToGdiBitmap();
        }
        protected static double[,] ToArray(Size size, NoiseMap noise)
        {
            var map = new double[size.Width, size.Height];

            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    map[x, y] = noise[x, y];
                }
            }

            return map;
        }

        protected enum ColorChannel
        {
            Alpha, Red, Green, Blue
        }
        protected static float ApplyOptionalProcessing(float value, NoiseConfig cfg)
        {
            value = ConstrainToThresholds(value, cfg);
            value = (cfg.Invert ? 1f : 0f) - value;
            value = cfg.OneBit ? (float)Math.Floor(value) : value;

            return Math.Abs(value);

        }
        protected static float ConstrainToThresholds(float val, NoiseConfig cfg)
        {
            return (val < cfg.MinThreshold || val > cfg.MaxThreshold)
                ? 0f
                : val;
        }
        protected static Color SetChannelValue(int value, ColorChannel channel = ColorChannel.Alpha)
        {
            return channel switch
            {
                ColorChannel.Alpha => Color.FromArgb(value, value, value, value),
                ColorChannel.Red => Color.FromArgb(0, value, 0, 0),
                ColorChannel.Green => Color.FromArgb(0, 0, value, 0),
                ColorChannel.Blue => Color.FromArgb(0, 0, 0, value),
                _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, null)
            };
        }

    }
}