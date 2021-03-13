using System;
using System.Drawing;

namespace GroanUI
{
    public class SystemRandomPlotter : NoisePlotter
    {
        private static readonly Random Random = new Random();

        protected override float PlotValue(int x, int y, Size size, NoiseConfig cfg)
        {
            return (float) Random.NextDouble();
        }
    }
}