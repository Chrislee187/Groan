using SharpNoise;

namespace GroanUI.Views.Main
{
    public class PerlinOptionsModel
    {
        public PerlinOptionsModel(float perlinFrequency, float perlinLacunarity, float perlinPersistance, int perlinOctaves)
        {
            Frequency = perlinFrequency;
            Lacunarity = perlinLacunarity;
            Persistance = perlinPersistance;
            Octaves = perlinOctaves;
            Quality = NoiseQuality.Standard;
        }

        public float Lacunarity { get; set; }
        public float Frequency { get; set; }
        public float Persistance { get; set; }
        public int Octaves { get; set; }
        public NoiseQuality Quality { get; set; }
    }
}