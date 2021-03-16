using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
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

            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource,
                EnableSeamless = false
            };

            noiseMapBuilder.SetDestSize(noiseMap.Width, noiseMap.Height);
            noiseMapBuilder.SetBounds(0, 1, 0, 1);

            noiseMapBuilder.Build();
            PostProcessing(size, cfg, noiseMap);
            return noiseMap;
        }

        private static void PostProcessing(Size size, NoiseConfig cfg, NoiseMap noiseMap)
        {
            if (RequiresPostProcessing(cfg))
            {
                var po = new ParallelOptions()
                {
                    CancellationToken = new CancellationToken(),
                };
                Parallel.For(0, size.Height, po, y =>
                {
                    for (int x = 0; x < size.Width; x++)
                    {
                        var v = noiseMap[x, y];

                        v = v < cfg.MinThreshold ? cfg.MinThreshold : v;
                        v = v > cfg.MaxThreshold ? cfg.MaxThreshold : v;
                        v = (cfg.Invert ? 1f : 0f) - v;
                        v = cfg.Round ? (int)Math.Round(v) : v;
                        noiseMap[x,y] = Math.Abs(v);
                    }
                });
            }
        }

        private static bool RequiresPostProcessing(NoiseConfig cfg)
        {
            return cfg.Invert || cfg.Round || cfg.MinThreshold > 0f || cfg.MaxThreshold < 1f;
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
            value = cfg.Round ? (float)Math.Floor(value) : value;

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