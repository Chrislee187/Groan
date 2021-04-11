using SharpNoise;
using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class PerlinConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Lacunarity { get; }
        public float Persistance { get; }
        public int Octaves { get; }
        public NoiseQuality Quality { get; }

        public PerlinConfig(float lacunarity, float frequency, float persistance, int octaves,
            NoiseQuality quality,
            NoiseConfig cfg
        ) : base(cfg)
        {
            Lacunarity = lacunarity;
            Frequency = frequency;
            Persistance = persistance;
            Octaves = octaves;
            Quality = quality;
        }


    }
    public class CellConfig : NoiseConfig
    {
        public float Frequency { get; }
        public float Displacement { get; }
        public Cell.CellType CellType { get; set; }
        public bool EnableDistance { get; set; }

        public CellConfig(float frequency, float displacement, Cell.CellType cellType, bool enabledDistance,
            NoiseConfig cfg
        ) : base(cfg)
        {
            Frequency = frequency;
            Displacement = displacement;
            CellType = cellType;
            EnableDistance = enabledDistance;
        }


    }
}