using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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

        public void SelectNoiseType(NoiseType noiseType)
        {
            _model.SelectedNoiseType = noiseType;

            View.DisableChangeEvents();
            
            View.SelectedNoise = noiseType;
            View.ShowOptionsTabFor(noiseType);
            InstantNoiseMapRedraw();
            
            View.EnableChangeEvents();
        }
        public void SelectOptionsTab(NoiseType noiseType)
        {
            View.DisableChangeEvents();
            _model.SelectedNoiseType = noiseType;
            
            View.SelectedNoise = noiseType;
            
            InstantNoiseMapRedraw();
            
            View.EnableChangeEvents();
        }
        public void SelectDefaultNoise()
        {
            View.DisableChangeEvents();

            _model.SelectedNoiseType = NoiseType.HorizontalGradient;
            
            View.ShowDefaultOptionsTab();

            InstantNoiseMapRedraw();
            
            View.EnableChangeEvents();
        }
        public void InvertNoise()
        {
            View.DisableChangeEvents();
            
            _model.InvertMap = !_model.InvertMap;
            InstantNoiseMapRedraw();

            View.EnableChangeEvents();
        }
        public void SetMinThreshold(int value)
        {
            View.DisableChangeEvents();

            _model.MinThreshold = (float)value / MainModel.ThresholdMaxValue;
            View.MinThresholdLabel = _model.MinThreshold;
            
            DelayedNoiseMapRedraw();

            View.EnableChangeEvents();
        }
        public void SetMaxThreshold(int value)
        {
            View.DisableChangeEvents();

            _model.MaxThreshold = (float)value / MainModel.ThresholdMaxValue;
            View.MaxThresholdLabel = _model.MaxThreshold;

            DelayedNoiseMapRedraw();

            View.EnableChangeEvents();
        }
        public void SetPerlinScale(int value)
        {
            if (value == _model.PerlinScale) return;
            View.DisableChangeEvents();

            _model.PerlinScale = value;
            View.PerlinScaleLabel = _model.PerlinScale;
            DelayedNoiseMapRedraw();

            View.EnableChangeEvents();
        }

        private Bitmap CreateNoiseBitmap(NoiseType noiseType, Size size)
        {
            var bmp = new Bitmap(
                size.Width,
                size.Height,
                PixelFormat.Format32bppRgb);

            var noise = _noiseProvider[noiseType];

            var noiseConfig = _configProviders[noiseType];

            noise.Plot(bmp, noiseConfig(_model));

            return bmp;
        }

        private readonly DefaultReturnDictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new (DefaultConfigProvider)
            {
                {NoiseType.Perlin, m => new PerlinConfig(m.InvertMap, m.MinThreshold, m.MaxThreshold, m.PerlinScale)}
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model) 
            => new(model.InvertMap, model.MinThreshold, model.MaxThreshold);

        private readonly Dictionary<NoiseType, NoisePlotter> _noiseProvider
            = new()
            {
                { NoiseType.HorizontalGradient, new HGradientPlotter() },
                { NoiseType.VerticalGradient, new VGradientPlotter() },
                { NoiseType.Random, new SystemRandomPlotter() },
                { NoiseType.Perlin, new PerlinPlotter() },
            };

        private Task _refreshNoiseMapTask;
        private CancellationTokenSource _refreshTaskToken;

        private void DelayedNoiseMapRedraw()
        {
            if (_refreshNoiseMapTask == null)
            {
                _refreshTaskToken = new CancellationTokenSource();
            }
            else
            {
                _refreshTaskToken.Cancel();
                _refreshTaskToken = new CancellationTokenSource();
            }

            _refreshNoiseMapTask = Task.Delay(10, _refreshTaskToken.Token)
                .ContinueWith(t => InstantNoiseMapRedraw(), _refreshTaskToken.Token);
        }

        private void InstantNoiseMapRedraw()
            => View.NoiseMapImage = CreateNoiseBitmap(_model.SelectedNoiseType, _model.MapSize);

    }

    public class DefaultReturnDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public DefaultReturnDictionary(TValue dflt)
        {
            _default = dflt;
        }

        private TValue _default;

        public new TValue this[TKey i]
        {
            get
            {
                if (TryGetValue(i, out var value))
                {
                    return value;
                }

                return _default;
            }
        }
    }
}