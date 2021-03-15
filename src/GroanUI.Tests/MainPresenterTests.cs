using System.Drawing;
using GroanUI.Plotters;
using GroanUI.Views.Main;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace GroanUI.Tests
{
    public class MainPresenterTests
    {
        private MainPresenter _presenter;
        private MainViewMockery _viewMockery;
        private MainModel _model;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            _model = new MainModelBuilder().Build();
            _model.MapSize = new Size(1, 1);
            _viewMockery = new MainViewMockery();
            _presenter = new MainPresenter(_model, new Mock<INoiseFactory>().Object,0);
            _presenter.SetView(_viewMockery.Object);
            _presenter.Init();

            _viewMockery.SetupChangeEventManagementChecks();
        }

        [TearDown]
        public void TearDown()
        {
            _viewMockery.VerifyChangeEventsManaged();
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void NoiseTypeSelected_updates_the_selected_OptionsTab()
        {
            // _presenter.SelectNoiseType(NoiseType.VerticalGradient);
            //
            // _viewMockery.VerifyOptionsTabUpdated(NoiseType.VerticalGradient);
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void NoiseTypeSelected_updates_the_NoiseMap()
        {
            // _presenter.SelectNoiseType(NoiseType.VerticalGradient);
            //
            // _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void NoiseTypeSelected_updates_the_Model()
        {
            // _presenter.SelectNoiseType(NoiseType.VerticalGradient);
            //
            // _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void OptionsTabSelected_updates_the_Model()
        {
            // _presenter.SelectOptionsTab(NoiseType.VerticalGradient);
            //
            // _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void OptionsTabSelected_updates_the_selected_NoiseType()
        {
            // _presenter.SelectOptionsTab(NoiseType.VerticalGradient);
            //
            // _viewMockery.VerifySelectedNoiseUpdated(NoiseType.VerticalGradient);
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void OptionsTabSelected_updates_the_NoiseMap()
        {
            // _presenter.SelectOptionsTab(NoiseType.VerticalGradient);
            //
            // _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void InvertNoise_updates_the_model()
        {
            _model.InvertMap.ShouldBeFalse();

            _presenter.InvertNoise();

            _model.InvertMap.ShouldBeTrue();
        }

        [Test]
        public void InvertNoise_updates_the_NoiseMap()
        {
            _presenter.InvertNoise();

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void OneBitToggle_updates_the_model()
        {
            _model.OneBit.ShouldBeFalse();

            _presenter.OneBitToggle();

            _model.OneBit.ShouldBeTrue();
        }

        [Test]
        public void OneBitToggle_updates_the_NoiseMap()
        {
            _presenter.OneBitToggle();

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetLacunarity_updates_the_Model()
        {
            _presenter.SetLacunarity(3);

            _model.Lacunarity.ShouldBe(3);
        }

        [Test]
        public void SetLacunarity_updates_the_NoiseMap()
        {
            _presenter.SetLacunarity(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetFrequency_updates_the_Model()
        {
            _presenter.SetFrequency(0.03f);

            _model.Frequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetFrequency_updates_the_NoiseMap()
        {
            _presenter.SetFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SelectDefaultNoise_updates_the_NoiseMap()
        {
            _presenter.SelectDefaultNoise();

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test, Ignore("Fix once have more than one noise type")]
        public void SelectDefaultNoise_updates_the_Model()
        {
            // _presenter.SelectDefaultNoise();
            //
            // _model.SelectedNoiseType.ShouldBe(NoiseType.HorizontalGradient);
        }

        [Test]
        public void SelectDefaultNoise_updates_the_OptionsTab()
        {
            _presenter.SelectDefaultNoise();

            _viewMockery.VerifyDefaultOptionsShown();
        }



    }
}