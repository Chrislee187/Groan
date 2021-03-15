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
        private readonly int _mapRefreshDelayMs;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="noiseFactory"></param>
        /// <param name="mapRefreshDelayMs">Introduce a small delay before refreshing the noise map to allow further
        /// changes to the config. i.e. When scrolling a scrollbar to change a value
        /// the redraw is not finished by the time the next scroll event arrive and produces
        /// a laggy UX. The delay is reset every time the Redraw is called.</param>
        public MainPresenter(MainModel model, INoiseFactory noiseFactory, int mapRefreshDelayMs=10)
        {
            _noiseFactory = noiseFactory;
            _model = model;
            _mapRefreshDelayMs = mapRefreshDelayMs;
        }
        public override void Init()
        {
            View.ViewTitle = _model.ViewTitle;
            View.MapSize = _model.MapSize;
            View.NoiseTypes = _model.NoiseTypes;
            View.GenerateGrayscale = _model.GenerateGrayscale;

            View.SetupSliders(_model.SliderSetups);
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

        public void SetLacunarity(float value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.Lacunarity = value;

                DelayedNoiseMapRedraw();
            });
        }

        public void SetFrequency(float value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.Frequency = value;

                DelayedNoiseMapRedraw();
            });
        }
        public void SetPersistance(float value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.Persistance = value;

                DelayedNoiseMapRedraw();
            });
        }
        public void SetOctaves(int value)
        {
            RunWithoutChangeEvents(() =>
            {
                _model.Octaves = value;

                DelayedNoiseMapRedraw();
            });
        }

        public void SetGrayscale(bool @checked)
        {
            RunWithoutChangeEvents(() =>
            {

                _model.GenerateGrayscale = @checked;
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

        private readonly DefaultDictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new(DefaultConfigProvider)
            {
                {
                NoiseType.Perlin,
                m => new PerlinConfig(m.GenerateGrayscale,
                    m.InvertMap, m.MinThreshold, m.MaxThreshold, m.OneBit,
                    m.NoiseScale, m.Lacunarity, m.Frequency, m.Persistance, m.Octaves
                    , m.XOffset, m.YOffset)
            }
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model)
            => new(model.InvertMap, model.MinThreshold, model.MaxThreshold, model.OneBit, model.NoiseScale, model.XOffset, model.YOffset, model.GenerateGrayscale);
        
        private CancellationTokenSource _cancelRefreshToken = new();
        private void DelayedNoiseMapRedraw()
        {
            if (_mapRefreshDelayMs > 0)
            {
                _cancelRefreshToken.Cancel();
                _cancelRefreshToken = new CancellationTokenSource();

                Task.Delay(_mapRefreshDelayMs, _cancelRefreshToken.Token)
                    .ContinueWith(_ => InstantNoiseMapRedraw(), _cancelRefreshToken.Token);
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
