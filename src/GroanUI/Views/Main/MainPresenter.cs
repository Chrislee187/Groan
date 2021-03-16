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
        /// a laggy UX. The delay is reset every time the Redraw is called. Set to '0' for testing.</param>
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
            View.Inverted = _model.Invert;
            View.Rounded = _model.Round;

            View.SetupSliders(_model.SliderSetups);
        }


        public void SelectNoiseType(NoiseType noiseType)
        {
            ExecuteAction(() =>
            {
                _model.SelectedNoiseType = noiseType;
                View.SelectedNoise = noiseType;
                View.ShowOptionsTabFor(noiseType);
            });
        }

        public void SelectOptionsTab(NoiseType noiseType)
        {
            ExecuteAction(() =>
            {
                _model.SelectedNoiseType = noiseType;

                View.SelectedNoise = noiseType;
            });
        }

        public void SelectDefaultNoise()
        {
            ExecuteAction(() =>
            {
                _model.SelectedNoiseType = NoiseType.Perlin;

                View.ShowDefaultOptionsTab();
            });
        }

        // Slider changes
        public void UpdateLacunarity(float value)
        {
            ExecuteAction(() =>
            {
                _model.Lacunarity = value;
            }, true);
        }
        public void UpdateFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.Frequency = value;
            }, true);
        }
        public void UpdatePersistance(float value)
        {
            ExecuteAction(() =>
            {
                _model.Persistance = value;

            }, true);
        }
        public void UpdateOctaves(int value)
        {
            ExecuteAction(() =>
            {
                _model.Octaves = value;
            }, true);
        }
        public void UpdateMinValue(float value)
        {
            ExecuteAction(() =>
            {
                _model.MinThreshold = value;
            }, true);
        }
        public void UpdateMaxValue(float value)
        {
            ExecuteAction(() =>
            {
                _model.MaxThreshold = value;
            }, true);
        }

        // Checkbox changes
        public void SetGrayscale(bool @checked)
        {
            ExecuteAction(() =>
            {
                _model.GenerateGrayscale = @checked;
            });
        }
        public void SetInverted(bool @checked)
        {
            ExecuteAction(() =>
            {
                _model.Invert = @checked;
            });
        }
        public void SetRounded(bool @checked)
        {
            ExecuteAction(() =>
            {
                _model.Round = @checked;
            });
        }

        // Other actions
        public void SetNewSeed()
        {
            ExecuteAction(() =>
            {
                _model.Seed = DateTime.Now.Ticks.GetHashCode();
            }, true);
        }

        private readonly DefaultDictionary<NoiseType, Func<MainModel, NoiseConfig>> _configProviders =
            new(DefaultConfigProvider)
            {
                {
                NoiseType.Perlin,
                m => new PerlinConfig(m.Lacunarity, m.Frequency, m.Persistance, m.Octaves, DefaultConfigProvider(m))
                }
            };

        private static NoiseConfig DefaultConfigProvider(MainModel model)
            => new(model.Invert, model.MinThreshold, model.MaxThreshold, model.Round, model.NoiseScale, model.GenerateGrayscale, model.Seed);
        
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

        /// <summary>
        /// Calls View.DisabledChangeEvents() before running the action, then 
        /// updates the Preview image (with an optional delay) before 
        /// calling View.EnabledChangeEvents() after the action.
        ///
        /// Use to avoid any cascading events when changing values from the presenter.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="withDelay">Delay the update slightly, use when responding to events from
        /// controls that give multiple updates such as ScrollBar and TrackBar 'Scroll' events.
        /// </param>
        private void ExecuteAction(Action action, bool withDelay = false)
        {
            View.DisableChangeEvents();

            action();

            if (withDelay)
            {
                DelayedNoiseMapRedraw();
            }
            else
            {
                InstantNoiseMapRedraw();
            }

            View.EnableChangeEvents();
        }
    }

}
