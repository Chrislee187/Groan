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
            View.SetupSliders(SliderSetups());

            View.NoiseScale = _model.NoiseScale;
            View.NoiseScaleLabel = (int)_model.NoiseScale;

            View.MinThreshold = (int)_model.MinThreshold * 1000;
            View.MinThresholdLabel = _model.MinThreshold;
            
            View.MaxThreshold = (int)_model.MaxThreshold * 1000;
            View.MaxThresholdLabel = _model.MaxThreshold;
            
            View.XOffsetLabel = _model.XOffset;
            View.YOffset = _model.XOffset;
            
            View.YOffsetLabel = _model.YOffset;
            View.XOffset = _model.XOffset;
        }

        private DecimalSlider.Configuration[] SliderSetups()
        {
            var SliderConversionFactor = 100f;
            return new []
            {
                new DecimalSlider.Configuration(
                    MainForm.Sliders.PerlinFrequency,
                    _model.PerlinFrequency,
                    1, 500,
                    SliderConversionFactor),
                new DecimalSlider.Configuration(
                    MainForm.Sliders.PerlinLacunarity,
                    _model.PerlinLacunarity,
                    1, 500,
                    SliderConversionFactor),

            };
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
                _model.SelectedNoiseType = NoiseType.Perlin;

                View.ShowDefaultOptionsTab();

                InstantNoiseMapRedraw();
            });
        }

        public void SetPerlinLacunarity(float value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.PerlinLacunarity = value;

                DelayedNoiseMapRedraw();
            });
        }

        public void SetPerlinFrequency(float value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.PerlinFrequency = value;

                DelayedNoiseMapRedraw();
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

        public void SetNoiseScale(int value)
        {
            if (value == _model.NoiseScale) return;
            RunWithoutChangeEvents(() =>
            {

                _model.NoiseScale = (float) value / 100;
                View.NoiseScaleLabel = _model.NoiseScale;
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
                    m.NoiseScale, m.PerlinLacunarity, m.PerlinFrequency
                    , m.XOffset, m.YOffset)
            }
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model)
            => new(model.InvertMap, model.MinThreshold, model.MaxThreshold, model.OneBit, model.NoiseScale, model.XOffset, model.YOffset);
        
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
