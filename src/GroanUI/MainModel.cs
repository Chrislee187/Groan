using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GroanUI
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
        public int PerlinScale { get; set; }

        public MainModel()
        {
            ViewTitle = "Noise Map Generator";
            NoiseTypes = new List<ListItem<NoiseType, string>>
            {
                new(NoiseType.HorizontalGradient, "Horizontal Gradient")
                ,new(NoiseType.VerticalGradient, "Vertical Gradient")
                ,new(NoiseType.Random, "Random")
                ,new(NoiseType.Perlin, "Perlin")
            };
            MapSize = new Size(400, 400);
            SelectedNoiseType = NoiseTypes.First().ID;

            MinThreshold = 0.0f;
            MaxThreshold = 1.0f;

            PerlinScale = PerlinPlotter.PerlinDefaultScale;
        }
    }

    public enum NoiseType
    {
        HorizontalGradient,
        VerticalGradient,
        Random,
        Perlin
    }
}