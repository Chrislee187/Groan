using System;
using System.Drawing;
using System.Numerics;

namespace GroanUI.Plotters
{
    public class PerlinPlotter : NoisePlotter
    {
        public const int PerlinDefaultScale = 100;
        public const int PerlinDefaultNumberOfOctaves = 5;
        public const float PerlinDefaultPersistence = 0.4f;
        public const float PerlinDefaultLacunarity = 2f;
        public static float InverseLerp(float a, float b, float value) => (double)a != (double)b ? Math.Clamp((float)(((double)value - (double)a) / ((double)b - (double)a)), 0f, 1f) : 0.0f;
        // public static float Lerp(float a, float b, float t) => a + (b - a) * Math.Clamp(t, 0f, 1f);

        public override void Plot(Bitmap b, NoiseConfig cfg)
        {
            var pcfg = (PerlinConfig) cfg;
            var theOffset = Vector2.Zero;
            var maxNoiseHeight = float.MinValue;
            var minNoiseHeight = float.MaxValue;

            var noiseMap = new float[b.Width, b.Height];

            var octaves = PerlinDefaultNumberOfOctaves;
            var seed = 0;
            var scale = pcfg.Scale;
            var persistence = PerlinDefaultPersistence;
            var lacunarity = PerlinDefaultLacunarity;
            var octaveOffsets = CreateOctaves(octaves, theOffset, seed);
            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    var noiseHeight = CalculatePerlinNoise(x , y , scale, persistence, lacunarity, octaveOffsets,
                        pcfg.Amplitude, pcfg.Frequency);

                    maxNoiseHeight = Math.Max(noiseHeight, maxNoiseHeight);
                    minNoiseHeight = Math.Min(noiseHeight, minNoiseHeight);

                    noiseMap[x, y] = noiseHeight;
                }

            }

            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    var plotValue = InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                    plotValue = ConfigureValue(plotValue, cfg);

                    b.SetPixel(x, y, SetChannelValue((int)(255 * plotValue)));
                }
            }
        }

        protected override float PlotValue(int x, int y, Size size, NoiseConfig cfg)
        {
            throw new InvalidOperationException($"PlotValue() not required by {nameof(PerlinPlotter)}");
        }

        private static Vector2[] CreateOctaves(int octaves, Vector2 offset, int seed)
        {
            var random = new Random(seed);
            var octaveOffsets = new Vector2[octaves];
            for (var i = 0; i < octaves; i++)
            {
                var offsetX = random.Next(0, RandomRange) + offset.X;
                var offsetY = random.Next(0, RandomRange) + offset.Y;

                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            return octaveOffsets;
        }


        private static float CalculatePerlinNoise(float x, float y, float scale, float persistence,
            float lacunarity,
            Vector2[] octaveOffsets,
            float amplitude = 1f,
            float frequency = 1f)
        {
            // NOTE: Higher the freq, further apart sample points will be, which means height values will change more rapidly

            var noiseHeight = 0f;
            return Noise.Generate(
                x / scale,
                y / scale) * amplitude;
            // return Noise.Generate(
            //     x / scale * frequency,
            //     y /scale * frequency) * amplitude;
            // for (var i = 0; i < octaveOffsets.Length; i++)
            // {
            //     var sampleX = x / scale * frequency + octaveOffsets[i].X;
            //     var sampleY = y / scale * frequency + octaveOffsets[i].Y;
            //
            //     var perlinValue = Noise.Generate(sampleX, sampleY) * 2 - 1; // Make in the range -1 : 1
            //     noiseHeight += perlinValue * amplitude;
            //
            //     amplitude *= persistence;
            //     frequency *= lacunarity;
            // }
            //
            // return noiseHeight;
        }


        /// <summary>
        /// Apparently PerlinNoise function starts to produce more repetitive data outside of this range (source https://youtu.be/MRNFcywkUSA?t=432) 
        /// </summary>
        private const int RandomRange = 100000;

    }
}