using SharpNoise.Modules;

namespace GroanUI.Views.Main
{
    public class CellOptionsModel
    {
        public CellOptionsModel(float cellFrequency, float cellDisplacement)
        {
            Frequency = cellFrequency;
            Displacement = cellDisplacement;
            CellType = Cell.CellType.Voronoi;
        }

        public float Frequency { get; set; }
        public float Displacement { get; set; }
        public Cell.CellType CellType { get; set; }
        public bool EnableDistance { get; set; }
    }
}