using NUnit.Framework;
using SharpNoise;
using Shouldly;

namespace GroanUI.Tests
{
    public partial class MainPresenterTests 
    {
        [TestFixture]
        public class PerlinConfig : MainPresenterTestBase
        {
            [Test]
            public void SetPerlinLacunarity_updates_the_Mode()
            {
                Presenter.UpdatePerlinLacunarity(3);

                Model.PerlinOptions.Lacunarity.ShouldBe(3);
            }

            [Test]
            public void SetPerlinLacunarity_updates_the_NoiseMap()
            {
                Presenter.UpdatePerlinLacunarity(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetPerlinFrequency_updates_the_Model()
            {
                Presenter.UpdatePerlinFrequency(0.03f);

                Model.PerlinOptions.Frequency.ShouldBe(0.03f);
            }


            [Test]
            public void SetPerlinFrequency_updates_the_NoiseMap()
            {
                Presenter.UpdatePerlinFrequency(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetPerlinOctaves_updates_the_Model()
            {
                Presenter.UpdatePerlinOctaves(2);

                Model.PerlinOptions.Octaves.ShouldBe(2);
            }

            [Test]
            public void SetPerlinOctaves_updates_the_NoiseMap()
            {
                Presenter.UpdatePerlinOctaves(2);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetPerlinPersistance_updates_the_Model()
            {
                Presenter.UpdatePerlinPersistance(1.5f);

                Model.PerlinOptions.Persistance.ShouldBe(1.5f);
            }

            [Test]
            public void SetPerlinPersistance_updates_the_NoiseMap()
            {
                Presenter.UpdatePerlinPersistance(1.5f);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetPerlinQuality_updates_the_Model()
            {
                Presenter.SelectPerlinQuality(NoiseQuality.Fast);

                Model.PerlinOptions.Quality.ShouldBe(NoiseQuality.Fast);
            }


            [Test]
            public void SetPerlinQuality_updates_the_NoiseMap()
            {
                Presenter.SelectPerlinQuality(NoiseQuality.Fast);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }
        }
    }
}