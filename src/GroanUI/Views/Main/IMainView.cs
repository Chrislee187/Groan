using System.Collections.Generic;
using System.Drawing;
using GroanUI.Util;
using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Views.Main
{
    public interface IMainView 
    {
        public string ViewTitle { set; }
        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { set; }
        IEnumerable<ListItem<NoiseQuality, string>> NoiseQualities { set; }
        IEnumerable<ListItem<Cell.CellType, string>> CellTypes { set; }
        public Size MapSize { set; }
        public Bitmap NoiseMapImage { set; }
        NoiseType SelectedNoise { set; }
        bool GenerateGrayscale { set; }
        bool Inverted { set; }
        bool Rounded { set; }
        NoiseQuality SelectedPerlinQuality { set; }
        NoiseQuality SelectedBillowQuality { set; }
        Cell.CellType SelectedCellType { set; }

        void ShowOptionsTabFor(NoiseType noiseType);
        void ShowDefaultOptionsTab();

        /// <summary>
        /// For the View to disable events that may be triggered
        /// by programmatic changes, typically disabled/enabled in
        /// Presenter actions that need to update visual elements
        /// without the "change" events triggering cascading updates
        /// </summary>
        void DisableChangeEvents();
        /// <summary>
        /// Reenable events that were disabled in <see cref="DisableChangeEvents"/>
        /// </summary>
        void EnableChangeEvents();

        void SetupSliders(params DecimalSlider.Configuration[] sliderSetup);
    }
}