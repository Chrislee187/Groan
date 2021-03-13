using System.Collections.Generic;
using System.Drawing;

namespace GroanUI
{
    public interface IMainView 
    {
        public string ViewTitle { set; }
        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { set; }
        public Size MapSize { set; }
        public Bitmap NoiseMapImage { set; }
        NoiseType SelectedNoise { set; }
        float MinThresholdValue { set; }
        float MaxThresholdValue { set; }

        void ShowOptionsTabFor(NoiseType noiseType);
        void ShowDefaultOptionsTab();

        void DisableChangeEvents();
        void EnableChangeEvents();
    }
}