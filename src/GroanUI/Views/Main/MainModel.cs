using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GroanUI.Util;

namespace GroanUI.Views.Main
{
    public class MainModel
    {
        public const int ThresholdMaxValue = 1000;
        public string ViewTitle { get; }

        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { get;}

        public Size MapSize { get; set; }
        public bool InvertMap { get; set; }
        public NoiseType SelectedNoiseType { get; set; }

        public float MinThreshold { get; set; }
        public float MaxThreshold { get; set; }
        public float NoiseScale { get; set; }
        public bool OneBit { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }

        public float PerlinLacunarity { get; set; }
        public float PerlinFrequency { get; set; }


        public DecimalSlider.Configuration[] SliderSetups { get; set; }
    

        public MainModel()
        {
            ViewTitle = "Noise Map Visualiser";
            NoiseTypes = new List<ListItem<NoiseType, string>>
            {
                new(NoiseType.Perlin, "Perlin (SharpNoise)"),
            };
            MapSize = new Size(400, 400);
            SelectedNoiseType = NoiseTypes.First().ID;

            MinThreshold = 0f;
            MaxThreshold = 1f;

            NoiseScale = 1f;
            OneBit = false;
            PerlinFrequency = 1f;
            PerlinLacunarity = 2f;
            XOffset = 0;
            YOffset = 0;

            var SliderConversionFactor = 100f;
            SliderSetups = new [] {
                new DecimalSlider.Configuration(
                    Sliders.PerlinFrequency,
                    PerlinFrequency,
                    1, 500,
                    SliderConversionFactor),
                new DecimalSlider.Configuration(
                    Sliders.PerlinLacunarity,
                    PerlinLacunarity,
                    1, 500,
                    SliderConversionFactor),
            };
        }
    }
    public enum Sliders
    {
        PerlinFrequency,
        PerlinLacunarity
    }

    public enum NoiseType
    {
        Perlin
    }
}