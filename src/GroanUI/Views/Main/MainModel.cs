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

        public float Lacunarity { get; set; }
        public float Frequency { get; set; }
        public float Persistance { get; set; }
        public int Octaves { get; set; }
        public bool GenerateGrayscale { get; set; }


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

            Frequency = 1f;
            Lacunarity = 2f;
            Persistance = 1f;
            Octaves = 6;
            GenerateGrayscale = true;

            MinThreshold = 0f;
            MaxThreshold = 1f;
            NoiseScale = 1f;
            OneBit = false;
            XOffset = 0;
            YOffset = 0;

            var SliderConversionFactor = 100f;
            SliderSetups = new [] {
                new DecimalSlider.Configuration(
                    Sliders.Frequency,
                    Frequency,
                    1, 500,
                    SliderConversionFactor),
                new DecimalSlider.Configuration(
                    Sliders.Lacunarity,
                    Lacunarity,
                    1, 500,
                    SliderConversionFactor),
                new DecimalSlider.Configuration(
                    Sliders.Persistance,
                    Persistance,
                    0, 200,
                    SliderConversionFactor),
                new DecimalSlider.Configuration(
                    Sliders.Octaves,
                    Octaves,
                    1, 15,
                    1
                    , 1, 1),

            };
        }
    }
    public enum Sliders
    {
        Frequency,
        Lacunarity,
        Persistance,
        Octaves
    }

    public enum NoiseType
    {
        Perlin
    }
}