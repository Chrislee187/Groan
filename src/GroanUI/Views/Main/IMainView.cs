using System.Collections.Generic;
using System.Drawing;
using GroanUI.Util;

namespace GroanUI.Views.Main
{
    public interface IMainView 
    {
        public string ViewTitle { set; }
        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { set; }
        public Size MapSize { set; }
        public Bitmap NoiseMapImage { set; }
        NoiseType SelectedNoise { set; }
        
        float MinThresholdLabel { set; }
        float MaxThresholdLabel { set; }
        int PerlinScaleLabel { set; }
        float PerlinAmplitudeLabel { set; }
        float PerlinFrequencyLabel { set; }
        int PerlinAmplitudeScrollValue { set; }
        int PerlinFrequencyScrollValue { set; }
        int MinThreshold { set; }
        int MaxThreshold { set; }

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
    }
}