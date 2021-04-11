using SharpNoise;

namespace GroanUI.Views.Main
{
    public class BillowOptionsModel
    {
        public BillowOptionsModel(float billowFrequency, float billowLacunarity, float billowPersistance, int billowOctaves)
        {
            Frequency = billowFrequency;
            Lacunarity = billowLacunarity;
            Persistance = billowPersistance;
            Octaves = billowOctaves;
            Quality = NoiseQuality.Standard;
        }

        public float Lacunarity { get; set; }
        public float Frequency { get; set; }
        public float Persistance { get; set; }
        public int Octaves { get; set; }
        public NoiseQuality Quality { get; set; }
    }
}