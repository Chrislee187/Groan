using System.Drawing;

namespace GroanUI
{
    public class HGradientPlotter : NoisePlotter
    {
        protected override float PlotValue(int x, int y, Size size, NoiseConfig cfg)
        {
            return (float) x / size.Width;
        }
    }
}