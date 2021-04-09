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

                Model.CellFrequency.ShouldBe(0.03f);
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

                Model.CellType.ShouldBe(Cell.CellType.Quadratic);
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

                Model.CellDisplacement.ShouldBe(0.03f);
            }

            [Test]
            public void SetCellDisplacement_updates_the_NoiseMap()
            {
                Presenter.UpdateCellDisplacement(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

        }

    }
}