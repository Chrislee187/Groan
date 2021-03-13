using System;
using System.Drawing;

namespace GroanUI
{
    public abstract class NoisePlotter
    {
        public enum ColorChannel
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
                    plotValue = ConfigureValue(plotValue, cfg);

                    b.SetPixel(x, y, SetChannelValue((int)(255 * plotValue)));
                }
            }
        }

        protected float ConfigureValue(float value, NoiseConfig cfg)
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
    }
}