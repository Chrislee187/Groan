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
                _model.PerlinOptions.Quality = quality;
                View.SelectedPerlinQuality = quality;
            });
        }
        public void SelectCellType(Cell.CellType cellType)
        {
            ExecuteAction(() =>
            {
                _model.CellOptions.CellType = cellType;
                View.SelectedCellType = cellType;
            });
        }

        public void SelectBillowQuality(NoiseQuality quality)
        {
            ExecuteAction(() =>
            {
                _model.BillowOptions.Quality = quality;
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
                _model.PerlinOptions.Lacunarity = value;
            }, true);
        }
        public void UpdatePerlinFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinOptions.Frequency = value;
            }, true);
        }
        public void UpdatePerlinPersistance(float value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinOptions.Persistance = value;

            }, true);
        }
        public void UpdatePerlinOctaves(int value)
        {
            ExecuteAction(() =>
            {
                _model.PerlinOptions.Octaves = value;
            }, true);
        }

        public void UpdateBillowLacunarity(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowOptions.Lacunarity = value;
            }, true);
        }
        public void UpdateBillowFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowOptions.Frequency = value;
            }, true);
        }
        public void UpdateBillowPersistance(float value)
        {
            ExecuteAction(() =>
            {
                _model.BillowOptions.Persistance = value;

            }, true);
        }
        public void UpdateBillowOctaves(int value)
        {
            ExecuteAction(() =>
            {
                _model.BillowOptions.Octaves = value;
            }, true);
        }


        public void UpdateCylinderFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.CylinderOptions.Frequency = value;
            }, true);
        }
        public void UpdateCellFrequency(float value)
        {
            ExecuteAction(() =>
            {
                _model.CellOptions.Frequency = value;
            }, true);
        }
        public void UpdateCellDisplacement(float value)
        {
            ExecuteAction(() =>
            {
                _model.CellOptions.Displacement = value;
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
        public void SetCellEnableDistance(bool @checked)
        {
            ExecuteAction(() =>
            {
                _model.CellEnableDistance = @checked;
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
                {NoiseType.Perlin, m => new PerlinConfig(m.PerlinOptions.Lacunarity, m.PerlinOptions.Frequency, m.PerlinOptions.Persistance, m.PerlinOptions.Octaves, m.PerlinOptions.Quality, DefaultConfigProvider(m))},
                {NoiseType.Billow, m => new PerlinConfig(m.BillowOptions.Lacunarity, m.BillowOptions.Frequency, m.BillowOptions.Persistance, m.BillowOptions.Octaves, m.BillowOptions.Quality, DefaultConfigProvider(m))},
                {NoiseType.Cylinder, m => new CylinderConfig(m.CylinderOptions.Frequency, DefaultConfigProvider(m))},
                {NoiseType.Cell, m => new CellConfig(m.CellOptions.Frequency, m.CellOptions.Displacement, m.CellOptions.CellType, m.CellEnableDistance, DefaultConfigProvider(m)) },
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
            View.ViewTitle = _noiseFactory.Info;

            View.EnableChangeEvents();
        }

    }

}
