using GroanUI.Views.Main;
using NUnit.Framework;
using Shouldly;

namespace GroanUI.Tests
{
    [TestFixture]
    public partial class MainPresenterTests
    {
        public class CommonConfig : MainPresenterTestBase
        {

            [Test]
            public void NoiseTypeSelected_updates_the_selected_OptionsTab()
            {
                Presenter.SelectNoiseType(NoiseType.Cylinder);

                ViewMockery.VerifyOptionsTabUpdated(NoiseType.Cylinder);
            }

            [Test]
            public void NoiseTypeSelected_updates_the_NoiseMap()
            {
                Presenter.SelectNoiseType(NoiseType.Cylinder);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void NoiseTypeSelected_updates_the_Model()
            {
                Presenter.SelectNoiseType(NoiseType.Cylinder);

                Model.SelectedNoiseType.ShouldBe(NoiseType.Cylinder);
            }

            [Test]
            public void OptionsTabSelected_updates_the_Model()
            {
                Presenter.SelectOptionsTab(NoiseType.Cylinder);

                Model.SelectedNoiseType.ShouldBe(NoiseType.Cylinder);
            }

            [Test]
            public void OptionsTabSelected_updates_the_selected_NoiseType()
            {
                Presenter.SelectOptionsTab(NoiseType.Cylinder);

                ViewMockery.VerifySelectedNoiseUpdated(NoiseType.Cylinder);
            }

            [Test]
            public void OptionsTabSelected_updates_the_NoiseMap()
            {
                Presenter.SelectOptionsTab(NoiseType.Cylinder);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }
            [Test]
            public void InvertNoise_updates_the_model()
            {
                Model.Invert.ShouldBeFalse();

                Presenter.SetInverted(true);

                Model.Invert.ShouldBeTrue();
            }

            [Test]
            public void InvertNoise_updates_the_NoiseMap()
            {
                Presenter.SetInverted(true);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void RoundToggle_updates_the_model()
            {
                Model.Round.ShouldBeFalse();

                Presenter.SetRounded(true);

                Model.Round.ShouldBeTrue();
            }

            [Test]
            public void RoundToggle_updates_the_NoiseMap()
            {
                Presenter.SetRounded(true);

                ViewMockery.VerifyNoiseMapImageUpdated();
            }


            [Test]
            public void SelectDefaultNoise_updates_the_NoiseMap()
            {
                Presenter.SelectDefaultNoise();

                ViewMockery.VerifyNoiseMapImageUpdated();
            }

            [Test]
            public void SelectDefaultNoise_updates_the_Model()
            {
                Presenter.SelectDefaultNoise();

                Model.SelectedNoiseType.ShouldBe(NoiseType.Perlin);
            }

            [Test]
            public void SelectDefaultNoise_updates_the_OptionsTab()
            {
                Presenter.SelectDefaultNoise();

                ViewMockery.VerifyDefaultOptionsShown();
            }
        }
    }
}