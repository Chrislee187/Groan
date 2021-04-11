using NUnit.Framework;
using SharpNoise.Modules;
using Shouldly;

namespace GroanUI.Tests
{
    public partial class MainPresenterTests 
    {
        [TestFixture]
        public class CellConfig : MainPresenterTestBase
        {
            [Test]
            public void SetCellFrequency_updates_the_Model()
            {
                Presenter.UpdateCellFrequency(0.03f);

                Model.CellOptions.Frequency.ShouldBe(0.03f);
            }

            [Test]
            public void SetCellFrequency_updates_the_NoiseMap()
            {
                Presenter.UpdateCellFrequency(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetCellType_updates_the_Model()
            {
                Presenter.SelectCellType(Cell.CellType.Quadratic);

                Model.CellOptions.CellType.ShouldBe(Cell.CellType.Quadratic);
            }
            [Test]
            public void SetCellType_updates_the_NoiseMap()
            {
                Presenter.SelectCellType(Cell.CellType.Quadratic);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }
            [Test]
            public void SetCellDisplacement_updates_the_Model()
            {
                Presenter.UpdateCellDisplacement(0.03f);

                Model.CellOptions.Displacement.ShouldBe(0.03f);
            }

            [Test]
            public void SetCellDisplacement_updates_the_NoiseMap()
            {
                Presenter.UpdateCellDisplacement(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetCellEnableDistance_updates_the_Model()
            {
                Model.CellEnableDistance.ShouldBeFalse();

                Presenter.SetCellEnableDistance(true);

                Model.CellEnableDistance.ShouldBeTrue();
            }

            [Test]
            public void SetCellEnableDistance_updates_the_NoiseMap()
            {
                Presenter.SetCellEnableDistance(true);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

        }

    }
}