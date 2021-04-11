using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GroanUI.Util;
using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Views.Main
{
    public class MainModel
    {
        public string ViewTitle { get; }

        public IEnumerable<ListItem<NoiseType, string>> NoiseTypes { get;}

        public IEnumerable<ListItem<NoiseQuality, string>> NoiseQualities
            => Enum.GetValues<NoiseQuality>()
                .Select(nq =>
                    new ListItem<NoiseQuality, string>(nq, nq.ToString()));

        public IEnumerable<ListItem<Cell.CellType, string>> CellTypes
            => new []{ Cell.CellType.Voronoi, Cell.CellType.Quadratic, 
                        Cell.CellType.Manhattan, Cell.CellType.Chebychev}
                .Select(cellType =>
                    new ListItem<Cell.CellType, string>(cellType, cellType.ToString()));

        public Size MapSize { get; set; }

        public int Seed { get; set; }
        public bool Invert { get; set; }
        public bool Round { get; set; }
        public bool GenerateGrayscale { get; set; }

        public NoiseType SelectedNoiseType { get; set; }

        public float MinThreshold { get; set; }
        public float MaxThreshold { get; set; }

        public float NoiseScale { get; set; }

        public DecimalSlider.Configuration[] SliderSetups { get; }
        public bool CellEnableDistance { get; set; }

        public PerlinOptionsModel PerlinOptions { get; }
        public BillowOptionsModel BillowOptions { get; }
        public CylinderOptionsModel CylinderOptions { get; }
        public CellOptionsModel CellOptions { get; }

        public MainModel()
        {
            ViewTitle = "Noise Map Visualiser";
            MapSize = new Size(400, 400);

            NoiseTypes = new List<ListItem<NoiseType, string>>
            {
                new(NoiseType.Perlin, "Perlin (SharpNoise)"),
                new(NoiseType.Billow, "Billow (SharpNoise)"),
                new(NoiseType.Cylinder, "Cylinder (SharpNoise)"),
                new(NoiseType.Cell, "Cell (SharpNoise)"),
            };

            SelectedNoiseType = NoiseTypes.First().ID;

            PerlinOptions = new PerlinOptionsModel(1f, 2f, 0.5f, 6);

            BillowOptions = new BillowOptionsModel(1f, 2f, 0.25f, 6);

            CylinderOptions = new CylinderOptionsModel(1.5f);

            CellOptions = new CellOptionsModel(1.0f, 1.5f);
            GenerateGrayscale = true;

            MinThreshold = 0f;
            MaxThreshold = 1f;
            NoiseScale = 1f;
            Round = false;
            Invert = false;

            Seed = 0;
            SliderSetups = new [] {
                new DecimalSlider.Configuration(Sliders.PerlinFrequency, PerlinOptions.Frequency, 0.01f, 5f),
                new DecimalSlider.Configuration(Sliders.PerlinLacunarity, PerlinOptions.Lacunarity, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.PerlinPersistance, PerlinOptions.Persistance, 0, 2f),
                new DecimalSlider.Configuration(Sliders.PerlinOctaves, PerlinOptions.Octaves, 1, 15, 1, 1, 0),

                new DecimalSlider.Configuration(Sliders.BillowFrequency, BillowOptions.Frequency, 0.01f, 25f),
                new DecimalSlider.Configuration(Sliders.BillowLacunarity, BillowOptions.Lacunarity, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.BillowPersistance, BillowOptions.Persistance, 0, 2f),
                new DecimalSlider.Configuration(Sliders.BillowOctaves, BillowOptions.Octaves, 1, 15, 1, 1, 0),


                new DecimalSlider.Configuration(Sliders.MinValue,
                    MinThreshold, 0, 1f),
                new DecimalSlider.Configuration(Sliders.MaxValue,
                    MaxThreshold, 0, 1f),
                new DecimalSlider.Configuration(Sliders.CylinderFrequency, CylinderOptions.Frequency, 0, 25f),


                new DecimalSlider.Configuration(Sliders.CellFrequency, CellOptions.Frequency, 0, 25f),
                new DecimalSlider.Configuration(Sliders.CellDisplacement, CellOptions.Displacement, 0, 25f),


                new DecimalSlider.Configuration(Sliders.Scale,
                    MinThreshold + 0.01f, 0+ 0.01f, 50f),

            };
        }
    }
    public enum Sliders
    {
        PerlinFrequency,
        PerlinLacunarity,
        PerlinPersistance,
        PerlinOctaves,
        MinValue,
        MaxValue,
        Scale,
        CylinderFrequency,
        BillowFrequency,
        BillowLacunarity,
        BillowPersistance,
        BillowOctaves,
        CellFrequency,
        CellDisplacement
    }

    public enum NoiseType
    {
        Perlin,
        Billow,
        Cylinder,
        Cell
    }
}