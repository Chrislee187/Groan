using NUnit.Framework;
using Shouldly;

namespace GroanUI.Tests
{
    [TestFixture]
    public partial class MainPresenterTests 
    {
        [TestFixture]
        public class CylinderConfig : MainPresenterTestBase
        {
            [Test]
            public void SetCylinderFrequency_updates_the_Model()
            {
                Presenter.UpdateCylinderFrequency(0.03f);

                Model.CylinderFrequency.ShouldBe(0.03f);
            }

            [Test]
            public void SetCylinderFrequency_updates_the_NoiseMap()
            {
                Presenter.UpdateCylinderFrequency(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }
        }
    }
}