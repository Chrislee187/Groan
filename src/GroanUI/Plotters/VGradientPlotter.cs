using System.Drawing;

namespace GroanUI.Plotters
{
    public class VGradientPlotter : NoisePlotter
    {
        protected override float PlotValue(int x, int y, Size size, NoiseConfig cfg)
        {
            return (float)y / size.Height;
        }
    }
}