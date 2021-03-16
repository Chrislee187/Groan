using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using SharpNoise;
using SharpNoise.Builders;
using SharpNoise.Modules;
using SharpNoise.Utilities.Imaging;
using Color = SharpNoise.Utilities.Imaging.Color;

namespace GroanUI.Plotters
{
    public abstract class NoiseBuilder
    {
        public float CoveragePercent { get; private set; }
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
            var count = PostProcessing(size, cfg, noiseMap);
            CoveragePercent = (float)count / (size.Width * size.Height);
            return noiseMap;
        }
        public virtual double[,] GetMap(Size size, NoiseConfig cfg) 
            => ToArray(size, BuildNoiseMap(size, cfg));

        public virtual NoiseMap GetNoiseMap(Size size, NoiseConfig cfg) 
            => BuildNoiseMap(size, cfg);

        public virtual Bitmap GetBitmap(Size size, NoiseConfig cfg)
        {
            var map = GetNoiseMap(size, cfg);
            return map.IsEmpty ? new Bitmap(1, 1) : CreateBitmap(size, map, cfg);
        }

        private static Bitmap CreateBitmap(Size size, NoiseMap map, NoiseConfig cfg)
        {
            var image = new SharpNoise.Utilities.Imaging.Image(size.Width, size.Height);
            var renderer = new ImageRenderer
            {
                SourceNoiseMap = map,
                DestinationImage = image
            };
            if (cfg.OutputGrayscale)
            {
                BuildGrayscaleRenderer(renderer);
            }
            else
            {
                BuildTerrainRenderer(renderer);
            }

            renderer.Render();

            return image.ToGdiBitmap();
        }

        private static int PostProcessing(Size size, NoiseConfig cfg, NoiseMap noiseMap)
        {
            var count = 0;
            var po = new ParallelOptions()
            {
                CancellationToken = new CancellationToken(),
            };
            Parallel.For(0, size.Height, po, y =>
            {
                for (int x = 0; x < size.Width; x++)
                {
                    var v = noiseMap[x, y];
                    v *= cfg.Scale;
                    v = v < cfg.MinThreshold ? cfg.MinThreshold : v;
                    v = v > cfg.MaxThreshold ? cfg.MaxThreshold : v;
                    v = (cfg.Invert ? 1f : 0f) - v;
                    v = cfg.Round ? (int)Math.Round(v) : v;
                    v = Math.Abs(v);
                    count += v > 0 ? 1 : 0;
                    noiseMap[x, y] = v;
                }
            });

            return count;
        }

        private static bool RequiresPostProcessing(NoiseConfig cfg) 
            => cfg.Invert || cfg.Round || cfg.MinThreshold > 0f || cfg.MaxThreshold < 1f
            || cfg.Scale < 1.0f || cfg.Scale > 1.0f;

        private static void BuildTerrainRenderer(ImageRenderer renderer)
        {
            renderer.ClearGradient();
            renderer.AddGradientPoint(0, new Color(0, 0, 128, 255));
            renderer.AddGradientPoint(0.4, new Color(32, 64, 128, 255));
            renderer.AddGradientPoint(0.46, new Color(64, 96, 192, 255));
            renderer.AddGradientPoint(0.48, new Color(192, 192, 128, 255));
            renderer.AddGradientPoint(0.5, new Color(0, 192, 0, 255));
            renderer.AddGradientPoint(0.625, new Color(192, 192, 0, 255));
            renderer.AddGradientPoint(0.75, new Color(160, 96, 64, 255));
            renderer.AddGradientPoint(0.875, new Color(128, 255, 255, 255));
            renderer.AddGradientPoint(1.00, new Color(255, 255, 255, 255));
        }

        private static void BuildGrayscaleRenderer(ImageRenderer renderer)
        {
            renderer.ClearGradient();
            renderer.AddGradientPoint(0, new Color(0, 0, 0, 255));
            renderer.AddGradientPoint(1D, new Color(255, 255, 255, 255));
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
    }
}