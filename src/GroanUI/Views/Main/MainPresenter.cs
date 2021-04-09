using System;
using System.Threading;
using System.Threading.Tasks;
using GroanUI.Plotters;
using GroanUI.Util;
using SharpNoise;
using SharpNoise.Modules;

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
            View.DisableChangeEvents();
            View.ViewTitle = _model.ViewTitle;
            View.MapSize = _model.MapSize;
            View.NoiseTypes = _model.NoiseTypes;
            View.NoiseQualities = _model.NoiseQualities;
            View.CellTypes = _model.CellTypes;
            View.GenerateGrayscale = _model.GenerateGrayscale;
            View.Inverted = _model.Invert;
            View.Rounded = _model.Round;

            View.SetupSliders(_model.SliderSetups);
            View.EnableChangeEvents();
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

        public void SelectPerlinQuality(NoiseQuality quality)
        {
            ExecuteAction(() =>
            {
                _model.PerlinQuality = quality;
                View.SelectedPerlinQuality = quality;
            });
        }
        public void SelectCellType(Cell.CellType cellType)
        {
            ExecuteAction(() =>
            {
                _model.CellType = cellType;
                View.SelectedCellType = cellType;
            });
        }

        public void SelectBillowQuality(NoiseQuality quality)
        {
            ExecuteAction(() =>
            {
                _model.BillowQuality = quality;
                View.SelectedBillowQuality = quality;
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
        public void UpdatePerlinLacunarity(float value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinLacunarity = value;
            }, true);
        }
        public void UpdatePerlinFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinFrequency = value;
            }, true);
        }
        public void UpdatePerlinPersistance(float value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinPersistance = value;

            }, true);
        }
        public void UpdatePerlinOctaves(int value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinOctaves = value;
            }, true);
        }

        public void UpdateBillowLacunarity(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowLacunarity = value;
            }, true);
        }
        public void UpdateBillowFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowFrequency = value;
            }, true);
        }
        public void UpdateBillowPersistance(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowPersistance = value;

            }, true);
        }
        public void UpdateBillowOctaves(int value)
        {
            ExecuteAction(() =>
            {
                _model.BillowOctaves = value;
            }, true);
        }


        public void UpdateCylinderFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.CylinderFrequency = value;
            }, true);
        }
        public void UpdateCellFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.CellFrequency = value;
            }, true);
        }
        public void UpdateCellDisplacement(float value)
        {
            ExecuteAction(() =>
            {
                _model.CellDisplacement = value;
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

        public void UpdateScale(float value)
        {
            ExecuteAction(() =>
            {
                _model.NoiseScale = value;
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
                {NoiseType.Perlin, m => new PerlinConfig(m.PerlinLacunarity, m.PerlinFrequency, m.PerlinPersistance, m.PerlinOctaves, m.PerlinQuality, DefaultConfigProvider(m))},
                {NoiseType.Billow, m => new PerlinConfig(m.BillowLacunarity, m.BillowFrequency, m.BillowPersistance, m.BillowOctaves, m.BillowQuality, DefaultConfigProvider(m))},
                {NoiseType.Cylinder, m => new CylinderConfig(m.CylinderFrequency, DefaultConfigProvider(m))},
                {NoiseType.Cell, m => new CellConfig(m.CellFrequency, m.CellDisplacement, m.CellType, DefaultConfigProvider(m)) },
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
        {
            View.NoiseMapImage = _noiseFactory.CreateNoiseBitmap(_model.SelectedNoiseType, _model.MapSize, _configProviders[_model.SelectedNoiseType](_model));
            // TODO: Display coverage
            //View.ViewTitle = "Coverage: " +  _noiseFactory.Coverage.ToString("P");
        }

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
