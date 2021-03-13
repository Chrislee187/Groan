using System;
using System.Threading;
using System.Threading.Tasks;

namespace GroanUI
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
            View.MinThresholdLabel = _model.MinThreshold;
            View.MaxThresholdLabel = _model.MaxThreshold;
            View.PerlinScaleLabel = _model.PerlinScale;
            View.PerlinAmplitudeLabel = _model.PerlinAmplitude;
            View.PerlinFrequencyLabel = _model.PerlinFrequency;
            View.PerlinAmplitudeScrollValue = (int) (_model.PerlinAmplitude * 100f);
            View.PerlinFrequencyScrollValue = (int) (_model.PerlinFrequency * 100f);
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
        public void OneBitToggle()
        {
            View.DisableChangeEvents();
            _model.OneBit = !_model.OneBit;
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
        public void SetPerlinAmplitude(int value)
        {
            View.DisableChangeEvents();

            _model.PerlinAmplitude = (float)value / 100;
            View.PerlinAmplitudeLabel = _model.PerlinAmplitude;

            DelayedNoiseMapRedraw();

            View.EnableChangeEvents();
        }
        public void SetPerlinFrequency(int value)
        {
            View.DisableChangeEvents();

            _model.PerlinFrequency = (float)value / 100;
            View.PerlinFrequencyLabel = _model.PerlinFrequency;

            DelayedNoiseMapRedraw();

            View.EnableChangeEvents();
        }


        private readonly DefaultDictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new (DefaultConfigProvider)
            {
                {NoiseType.Perlin, m => new PerlinConfig(
                    m.InvertMap, m.MinThreshold, m.MaxThreshold, m.OneBit, 
                    m.PerlinScale, m.PerlinAmplitude, m.PerlinFrequency)}
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
    }
}