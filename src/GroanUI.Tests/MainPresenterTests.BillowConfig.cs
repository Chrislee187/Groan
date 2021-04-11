using NUnit.Framework;
using SharpNoise;
using Shouldly;

namespace GroanUI.Tests
{
    public partial class MainPresenterTests 
    {
        [TestFixture]
        public class BillowConfig : MainPresenterTestBase
        {
            [Test]
            public void SetBillowLacunarity_updates_the_Mode()
            {
                Presenter.UpdateBillowLacunarity(3);

                Model.BillowOptions.Lacunarity.ShouldBe(3);
            }

            [Test]
            public void SetBillowLacunarity_updates_the_NoiseMap()
            {
                Presenter.UpdateBillowLacunarity(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetBillowFrequency_updates_the_Model()
            {
                Presenter.UpdateBillowFrequency(0.03f);

                Model.BillowOptions.Frequency.ShouldBe(0.03f);
            }

            [Test]
            public void SetBillowFrequency_updates_the_NoiseMap()
            {
                Presenter.UpdateBillowFrequency(3);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetBillowOctaves_updates_the_Model()
            {
                Presenter.UpdateBillowOctaves(2);

                Model.BillowOptions.Octaves.ShouldBe(2);
            }

            [Test]
            public void SetBillowOctaves_updates_the_NoiseMap()
            {
                Presenter.UpdateBillowOctaves(2);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetBillowPersistance_updates_the_Model()
            {
                Presenter.UpdateBillowPersistance(1.5f);

                Model.BillowOptions.Persistance.ShouldBe(1.5f);
            }

            [Test]
            public void SetBillowPersistance_updates_the_NoiseMap()
            {
                Presenter.UpdateBillowPersistance(1.5f);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SetBillowQuality_updates_the_Model()
            {
                Presenter.SelectBillowQuality(NoiseQuality.Fast);

                Model.BillowOptions.Quality.ShouldBe(NoiseQuality.Fast);
            }


            [Test]
            public void SetBillowQuality_updates_the_NoiseMap()
            {
                Presenter.SelectBillowQuality(NoiseQuality.Fast);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }
        }


    }
}