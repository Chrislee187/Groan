using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace GroanUI
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly MainModel _model;

        public MainPresenter(MainModel model)
        {
            _model = model;
        }

        public override void Init()
        {
            View.ViewTitle = _model.ViewTitle;
            View.MapSize = _model.MapSize;
            View.NoiseTypes = _model.NoiseTypes;
        }

        public void NoiseTypeSelected(NoiseType noiseType)
        {
            _model.SelectedNoiseType = noiseType;

            View.DisableChangeEvents();
            
            View.SelectedNoise = noiseType;
            View.ShowOptionsTabFor(noiseType);
            RedrawNoiseMap();
            
            View.EnableChangeEvents();
        }
        public void OptionsTabSelected(NoiseType noiseType)
        {
            View.DisableChangeEvents();
            _model.SelectedNoiseType = noiseType;
            
            View.SelectedNoise = noiseType;
            
            RedrawNoiseMap();
            
            View.EnableChangeEvents();
        }
        
        public void SelectDefaultOptionsTab()
        {
            View.DisableChangeEvents();

            _model.SelectedNoiseType = NoiseType.HorizontalGradient;
            
            View.ShowDefaultOptionsTab();

            RedrawNoiseMap();
            
            View.EnableChangeEvents();
        }
        
        public void InvertNoise()
        {
            View.DisableChangeEvents();
            
            _model.InvertMap = !_model.InvertMap;
            RedrawNoiseMap();

            View.EnableChangeEvents();
        }
        
        public void SetMinThreshold(int value)
        {
            View.DisableChangeEvents();

            _model.MinThreshold = (float)value / MainModel.ThresholdMaxValue;
            View.MinThresholdLabel = _model.MinThreshold;
            
            RedrawNoiseMap();

            View.EnableChangeEvents();
        }

        public void SetMaxThreshold(int value)
        {
            View.DisableChangeEvents();

            _model.MaxThreshold = (float)value / MainModel.ThresholdMaxValue;
            View.MaxThresholdLabel = _model.MaxThreshold;

            RedrawNoiseMap();

            View.EnableChangeEvents();
        }
        private void RedrawNoiseMap()
        {
            View.NoiseMapImage = CreateNoiseBitmap(_model.SelectedNoiseType, _model.MapSize, _model.InvertMap);
        }

        private Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size, bool invert)
        {
            var bmp = new Bitmap(
                size.Width,
                size.Height,
                PixelFormat.Format32bppRgb);

            var noise = _noiseProvider[noiseType];
            var cfg = _configProviders[_model.SelectedNoiseType](_model);

            for (var y = 0; y < size.Height - 1; y++)
            {
                for (var x = 0; x < size.Width - 1; x++)
                {
                    bmp.SetPixel(x, y, noise.Plot(x, y, bmp, cfg));
                }
            }

            return bmp;
        }

        private readonly Dictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new()
            {
                {NoiseType.HorizontalGradient, DefaultConfigProvider},
                {NoiseType.VerticalGradient, DefaultConfigProvider},
                {NoiseType.Random, DefaultConfigProvider}
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model) 
            => new(model.InvertMap, model.MinThreshold, model.MaxThreshold);

        private readonly Dictionary<NoiseType, NoisePlotter> _noiseProvider
            = new()
            {
                { NoiseType.HorizontalGradient, new HGradientPlotter() },
                { NoiseType.VerticalGradient, new VGradientPlotter() },
                { NoiseType.Random, new SystemRandomPlotter() },
            };

    }

    public class NoiseConfig
    {
        public NoiseConfig(bool invert, float minThreshold, float maxThreshold)
        {
            Invert = invert;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }

        public bool Invert { get; }
        public float MinThreshold { get; }
        public float MaxThreshold { get; }
    }

    public abstract class NoisePlotter
    {
        public enum ColorChannel
        {
            Alpha, Red, Green, Blue
        }

        // TODO: Move inversePlot int to a config object

        public abstract Color Plot(int x, int y, Bitmap b, NoiseConfig cfg);

        protected float ConstrainToThreshold(float val, NoiseConfig cfg)
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

    public class SystemRandomPlotter : NoisePlotter
    {
        private static readonly Random Random = new Random();

        public override Color Plot(int x, int y, Bitmap b, NoiseConfig cfg)
        {
            var val = (cfg.Invert ? 1f : 0f) - (float)Random.NextDouble();
            val = ConstrainToThreshold(Math.Abs(val), cfg);
            return SetChannelValue((int) (255 * val));
        }
    }

    public class HGradientPlotter : NoisePlotter
    {
        public override Color Plot(int x, int y, Bitmap b, NoiseConfig cfg)
        {
            var progress = (cfg.Invert ? 1f : 0f) - (float) x / b.Width;
            
            var val = ConstrainToThreshold(Math.Abs(progress), cfg);
            return SetChannelValue((int) (255 * val));
        }
    }

    public class VGradientPlotter : NoisePlotter
    {
        public override Color Plot(int x, int y, Bitmap b, NoiseConfig cfg)
        {
            var progress = (cfg.Invert ? 1f : 0f) - (float)y / b.Height;
            var val = ConstrainToThreshold(Math.Abs(progress), cfg);
            return SetChannelValue((int)(255 * val));
        }
    }
}