using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GroanUI.Util;

namespace GroanUI.Views.Main
{
    public class MainModel
    {
        public string ViewTitle { get; }

        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { get;}

        public Size MapSize { get; set; }

        public int Seed { get; set; }
        public bool Invert { get; set; }
        public bool Round { get; set; }
        public bool GenerateGrayscale { get; set; }

        public NoiseType SelectedNoiseType { get; set; }

        public float MinThreshold { get; set; }
        public float MaxThreshold { get; set; }

        public float Lacunarity { get; set; }
        public float Frequency { get; set; }
        public float Persistance { get; set; }
        public int Octaves { get; set; }

        public DecimalSlider.Configuration[] SliderSetups { get; }
        public float NoiseScale { get; }


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
            Round = false;
            Invert = false;

            Seed = 0;
            SliderSetups = new [] {
                new DecimalSlider.Configuration(Sliders.Frequency,
                    Frequency, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.Lacunarity,
                    Lacunarity, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.Persistance,
                    Persistance, 0, 2f),
                new DecimalSlider.Configuration(Sliders.Octaves,
                    Octaves, 1, 15, 1, 1, 0),
                new DecimalSlider.Configuration(Sliders.MinValue,
                    MinThreshold, 0, 1f),                
                new DecimalSlider.Configuration(Sliders.MaxValue,
                    MaxThreshold, 0, 1f),

            };
        }
    }
    public enum Sliders
    {
        Frequency,
        Lacunarity,
        Persistance,
        Octaves,
        MinValue,
        MaxValue
    }

    public enum NoiseType
    {
        Perlin
    }
}