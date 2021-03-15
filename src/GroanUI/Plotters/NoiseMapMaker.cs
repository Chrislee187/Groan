using System;
using System.Drawing;
using SharpNoise;
using SharpNoise.Utilities.Imaging;
using Color = System.Drawing.Color;

namespace GroanUI.Plotters
{
    public abstract class NoiseMapMaker
    {

        protected abstract NoiseMap BuildNoise(Size size, NoiseConfig cfg);
        public virtual double[,] GetMap(Size size, NoiseConfig cfg)
        {
            var pcfg = cfg as PerlinConfig;
            var noise = BuildNoise(size, pcfg);
            var map = ToArray(size, noise);
            return map;
        }
        public virtual NoiseMap GetNoiseMap(Size size, NoiseConfig cfg)
        {
            return BuildNoise(size, cfg as PerlinConfig);
        }

        public virtual Bitmap GetBitmap(Size size, NoiseConfig cfg)
        {
            var map = GetNoiseMap(size, cfg);
            if (map.IsEmpty) return new Bitmap(1, 1);
            return CreateGrayscaleBitmap(size, map);
        }



        protected enum ColorChannel
        {
            Alpha, Red, Green, Blue
        }

        protected abstract float PlotValue(int x, int y, Size size, NoiseConfig cfg);

        public virtual void Plot(Bitmap b, NoiseConfig cfg)
        {
            for (var y = 0; y < b.Height - 1; y++)
            {
                for (var x = 0; x < b.Width - 1; x++)
                {
                    var plotValue = PlotValue(x, y, b.Size, cfg);
                    plotValue = ApplyOptionalProcessing(plotValue, cfg);

                    b.SetPixel(x, y, SetChannelValue((int)(255 * plotValue)));
                }
            }
        }

        protected float ApplyOptionalProcessing(float value, NoiseConfig cfg)
        {
            value = ConstrainToThresholds(value, cfg);
            value = (cfg.Invert ? 1f : 0f) - value;
            value = cfg.OneBit ? (float)Math.Floor(value) : value;

            return Math.Abs(value);

        }
        protected float ConstrainToThresholds(float val, NoiseConfig cfg)
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

        protected static Bitmap CreateGrayscaleBitmap(Size size, NoiseMap map)
        {
            var image = new SharpNoise.Utilities.Imaging.Image(size.Width, size.Height);
            var renderer = new ImageRenderer
            {
                SourceNoiseMap = map,
                DestinationImage = image
            };

            renderer.BuildGrayscaleGradient();

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
    }
}