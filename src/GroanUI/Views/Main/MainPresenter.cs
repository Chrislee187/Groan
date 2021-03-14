using System;
using System.Threading;
using System.Threading.Tasks;
using GroanUI.Plotters;
using GroanUI.Util;

namespace GroanUI.Views.Main
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly INoiseFactory _noiseFactory;
        private readonly MainModel _model;

        public MainPresenter(MainModel model, INoiseFactory noiseFactory)
        {
            _noiseFactory = noiseFactory;
            _model = model;
        }

        public override void Init()
        {
            View.ViewTitle = _model.ViewTitle;
            View.MapSize = _model.MapSize;
            View.NoiseTypes = _model.NoiseTypes;
            View.MinThreshold = (int)_model.MinThreshold * 1000;
            View.MaxThreshold = (int)_model.MaxThreshold * 1000;
            View.MinThresholdLabel = _model.MinThreshold;
            View.MaxThresholdLabel = _model.MaxThreshold;
            View.PerlinScale = _model.PerlinScale;
            View.PerlinScaleLabel = _model.PerlinScale;
            View.PerlinAmplitudeLabel = _model.PerlinAmplitude;
            View.PerlinFrequencyLabel = _model.PerlinFrequency;
            View.PerlinAmplitudeScrollValue = (int)(_model.PerlinAmplitude * 100f);
            View.PerlinFrequencyScrollValue = (int)(_model.PerlinFrequency * 100f);
            View.XOffsetLabel = _model.XOffset;
            View.YOffset = _model.XOffset;
            View.YOffsetLabel = _model.YOffset;
            View.XOffset = _model.XOffset;
        }

        public void SelectNoiseType(NoiseType noiseType)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.SelectedNoiseType = noiseType;
                View.SelectedNoise = noiseType;
                View.ShowOptionsTabFor(noiseType);
                InstantNoiseMapRedraw();
            });
        }

        public void SelectOptionsTab(NoiseType noiseType)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.SelectedNoiseType = noiseType;

                View.SelectedNoise = noiseType;

                InstantNoiseMapRedraw();
            });
        }

        public void SelectDefaultNoise()
        {
            RunWithoutChangeEvents(() =>
            {
                _model.SelectedNoiseType = NoiseType.HorizontalGradient;

                View.ShowDefaultOptionsTab();

                InstantNoiseMapRedraw();
            });
        }

        public void InvertNoise()
        {
            RunWithoutChangeEvents(() =>
            {

                _model.InvertMap = !_model.InvertMap;
                InstantNoiseMapRedraw();

            });
        }

        public void OneBitToggle()
        {
            RunWithoutChangeEvents(() =>
            {
                _model.OneBit = !_model.OneBit;
                InstantNoiseMapRedraw();

            });
        }

        public void SetMinThreshold(int value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.MinThreshold = (float) value / MainModel.ThresholdMaxValue;
                View.MinThresholdLabel = _model.MinThreshold;

                DelayedNoiseMapRedraw();

            });
        }

        public void SetMaxThreshold(int value)
        {
            RunWithoutChangeEvents(() =>
            {

                _model.MaxThreshold = (float) value / MainModel.ThresholdMaxValue;
                View.MaxThresholdLabel = _model.MaxThreshold;

                DelayedNoiseMapRedraw();

            });
        }

        public void SetPerlinScale(int value)
        {
            if (value == _model.PerlinScale) return;
            RunWithoutChangeEvents(() =>
            {

                _model.PerlinScale = value;
                View.PerlinScaleLabel = _model.PerlinScale;
                DelayedNoiseMapRedraw();

            });
        }

        public void SetPerlinAmplitude(int value)
        {
            RunWithoutChangeEvents(() =>
            {

                _model.PerlinAmplitude = (float) value / 100;
                View.PerlinAmplitudeLabel = _model.PerlinAmplitude;

                DelayedNoiseMapRedraw();

            });
        }

        public void SetPerlinFrequency(int value)
        {
            RunWithoutChangeEvents(() =>
            {

                _model.PerlinFrequency = (float) value / 100;
                View.PerlinFrequencyLabel = _model.PerlinFrequency;

                DelayedNoiseMapRedraw();
            });
        }

        public void SetXOffset(int value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.XOffset = value;
                View.XOffsetLabel = _model.XOffset;

                DelayedNoiseMapRedraw();
            });
        }

        public void SetYOffset(int value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.YOffset = value;
                View.YOffsetLabel = _model.YOffset;

                DelayedNoiseMapRedraw();

            });
        }

        private readonly DefaultDictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new(DefaultConfigProvider)
            {
                {
                    NoiseType.Perlin,
                    m => new PerlinConfig(
                         m.InvertMap, m.MinThreshold, m.MaxThreshold, m.OneBit,
                         m.PerlinScale, m.PerlinAmplitude, m.PerlinFrequency
                         ,m.XOffset, m.YOffset)
                }
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model)
            => new(model.InvertMap, model.MinThreshold, model.MaxThreshold, model.OneBit);
        
        /// <summary>
        /// Introduce a small delay before refreshing the noise map to allow further
        /// changes to the config. i.e. When scrolling a scrollbar to change a value
        /// the redraw is not finished by the time the next scroll event arrive and produces
        /// a laggy UX. The delay is reset every time the Redraw is called.
        ///  </summary>
        public static int MapRefreshDelayMs = 10;

        private CancellationTokenSource _refreshTaskToken = new();
        private void DelayedNoiseMapRedraw()
        {
            if (MapRefreshDelayMs > 0)
            {
                _refreshTaskToken.Cancel();
                _refreshTaskToken = new CancellationTokenSource();

                Task.Delay(MapRefreshDelayMs, _refreshTaskToken.Token)
                    .ContinueWith(_ => InstantNoiseMapRedraw(), _refreshTaskToken.Token);
            }
            else
            {
                InstantNoiseMapRedraw();
            }
        }

        private void InstantNoiseMapRedraw()
            => View.NoiseMapImage = _noiseFactory.CreateNoiseBitmap(_model.SelectedNoiseType, _model.MapSize, _configProviders[_model.SelectedNoiseType](_model));

        private void RunWithoutChangeEvents(Action action)
        {
            View.DisableChangeEvents();
            action();
            View.EnableChangeEvents();
        }
    }
}
