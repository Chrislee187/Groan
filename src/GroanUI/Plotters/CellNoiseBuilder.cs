using System;
using System.Numerics;
using SharpNoise.Modules;

namespace GroanUI.Plotters
{
    public class CellNoiseBuilder : NoiseBuilder
    {
        // TODO: Seperate UI and config for this one
        protected override Module BuildNoiseSource(NoiseConfig cfg)
        {
            var pcfg = (CellConfig)cfg;
            var noiseSource = new Cell()
            {
                Type = pcfg.CellType,
                Seed = pcfg.Seed,
                Frequency = pcfg.Frequency,
                Displacement = pcfg.Displacement,
                EnableDistance = pcfg.EnableDistance
            };
            return noiseSource;
        }
    }
}