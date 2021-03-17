using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GroanUI.Util;
using SharpNoise;

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

        public Size MapSize { get; set; }

        public int Seed { get; set; }
        public bool Invert { get; set; }
        public bool Round { get; set; }
        public bool GenerateGrayscale { get; set; }

        public NoiseType SelectedNoiseType { get; set; }

        public float MinThreshold { get; set; }
        public float MaxThreshold { get; set; }

        public float PerlinLacunarity { get; set; }
        public float PerlinFrequency { get; set; }
        public float PerlinPersistance { get; set; }
        public int PerlinOctaves { get; set; }
        public NoiseQuality PerlinQuality { get; set; }

        public float BillowLacunarity { get; set; }
        public float BillowFrequency { get; set; }
        public float BillowPersistance { get; set; }
        public int BillowOctaves { get; set; }
        public NoiseQuality BillowQuality { get; set; }

        public float CylinderFrequency { get; set; }

        public float NoiseScale { get; set; }

        public DecimalSlider.Configuration[] SliderSetups { get; }

        public MainModel()
        {
            ViewTitle = "Noise Map Visualiser";
            NoiseTypes = new List<ListItem<NoiseType, string>>
            {
                new(NoiseType.Perlin, "Perlin (SharpNoise)"),
                new(NoiseType.Billow, "Billow (SharpNoise)"),
                new(NoiseType.Cylinder, "Cylinder (SharpNoise)"),
            };
            // NoiseQualities = Enum.GetValues<NoiseQuality>().Select(nq =>
            //     new ListItem<NoiseQuality, string>(nq, nq.ToString())
            // ).ToList();
            
            MapSize = new Size(400, 400);
            SelectedNoiseType = NoiseTypes.First().ID;

            PerlinFrequency = 1f;
            PerlinLacunarity = 2f;
            PerlinPersistance = 1f;
            PerlinOctaves = 6;
            PerlinQuality = NoiseQuality.Standard;

            BillowFrequency = 3f;
            BillowLacunarity = 2f;
            BillowPersistance = 0.5f;
            BillowOctaves = 6;
            BillowQuality = NoiseQuality.Standard;

            CylinderFrequency = 1.5f;
            GenerateGrayscale = true;

            MinThreshold = 0f;
            MaxThreshold = 1f;
            NoiseScale = 1f;
            Round = false;
            Invert = false;

            Seed = 0;
            SliderSetups = new [] {
                new DecimalSlider.Configuration(Sliders.PerlinFrequency,
                    PerlinFrequency, 0.01f, 5f),
                new DecimalSlider.Configuration(Sliders.PerlinLacunarity,
                    PerlinLacunarity, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.PerlinPersistance,
                    PerlinPersistance, 0, 2f),
                new DecimalSlider.Configuration(Sliders.PerlinOctaves,
                    PerlinOctaves, 1, 15, 1, 1, 0),

                new DecimalSlider.Configuration(Sliders.BillowFrequency,
                    BillowFrequency, 0.01f, 25f),
                new DecimalSlider.Configuration(Sliders.BillowLacunarity,
                    BillowLacunarity, 1f, 5f),
                new DecimalSlider.Configuration(Sliders.BillowPersistance,
                    BillowPersistance, 0, 2f),
                new DecimalSlider.Configuration(Sliders.BillowOctaves,
                    BillowOctaves, 1, 15, 1, 1, 0),


                new DecimalSlider.Configuration(Sliders.MinValue,
                    MinThreshold, 0, 1f),
                new DecimalSlider.Configuration(Sliders.MaxValue,
                    MaxThreshold, 0, 1f),
                new DecimalSlider.Configuration(Sliders.CylinderFrequency,
                    CylinderFrequency, 0, 25f),

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
        BillowOctaves
    }

    public enum NoiseType
    {
        Perlin,
        Billow,
        Cylinder
    }
}