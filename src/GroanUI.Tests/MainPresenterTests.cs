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
            MainPresenter.MapRefreshDelayMs.ShouldBeGreaterThan(0, "UX is degraded when using the sliders to change values without a refresh delay");
            MainPresenter.MapRefreshDelayMs = 0; // NOTE: Remove the UX improvement refresh delay for the purposes of testing
        }

        [SetUp]
        public void Setup()
        {
            _model = new MainModelBuilder().Build();
            _model.MapSize = new Size(1, 1);
            _viewMockery = new MainViewMockery();
            _presenter = new MainPresenter(_model, new Mock<INoiseFactory>().Object);
            _presenter.SetView(_viewMockery.Object);
            _presenter.Init();

            _viewMockery.SetupChangeEventManagementChecks();
        }

        [TearDown]
        public void TearDown()
        {
            _viewMockery.VerifyChangeEventsManaged();
        }

        [Test]
        public void NoiseTypeSelected_updates_the_selected_OptionsTab()
        {
            _presenter.SelectNoiseType(NoiseType.VerticalGradient);
            
            _viewMockery.VerifyOptionsTabUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void NoiseTypeSelected_updates_the_NoiseMap()
        {
            _presenter.SelectNoiseType(NoiseType.VerticalGradient);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void NoiseTypeSelected_updates_the_Model()
        {
            _presenter.SelectNoiseType(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_Model()
        {
            _presenter.SelectOptionsTab(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_selected_NoiseType()
        {
            _presenter.SelectOptionsTab(NoiseType.VerticalGradient);

            _viewMockery.VerifySelectedNoiseUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_NoiseMap()
        {
            _presenter.SelectOptionsTab(NoiseType.VerticalGradient);

            _viewMockery.VerifyNoiseMapImageUpdated();
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
        public void SetMinThreshold_updates_the_model()
        {
            _presenter.SetMinThreshold(500);

            _model.MinThreshold.ShouldBe(0.5f);
        }

        [Test]
        public void SetMinThreshold_updates_the_MinThresholdLabel()
        {
            _presenter.SetMinThreshold(500);

            _viewMockery.VerifyMinThresholdLabelUpdated();
        }

        [Test]
        public void SetMinThreshold_updates_the_NoiseMap()
        {
            _presenter.SetMinThreshold(500);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetMaxThreshold_updates_the_model()
        {
            _presenter.SetMaxThreshold(750);

            _model.MaxThreshold.ShouldBe(0.75f);
        }

        [Test]
        public void SetMaxThreshold_updates_the_MaxThresholdLabel()
        {
            _presenter.SetMaxThreshold(500);

            _viewMockery.VerifyMaxThresholdLabelUpdated();
        }
        [Test]
        public void SetMaxThreshold_updates_the_NoiseMap()
        {
            _presenter.SetMaxThreshold(500);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinScale_updates_the_Model()
        {
            _presenter.SetPerlinScale(3);

            _model.PerlinScale.ShouldBe(3);
        }
        [Test]
        public void SetPerlinScale_updates_the_PerlinAmplitudeLabel()
        {
            _presenter.SetPerlinScale(3);

            _viewMockery.VerifyPerlinScaleLabelUpdated();
        }
        [Test]
        public void SetPerlinScale_updates_the_NoiseMap()
        {
            _presenter.SetPerlinScale(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinAmplitude_updates_the_Model()
        {
            _presenter.SetPerlinAmplitude(3);

            _model.PerlinAmplitude.ShouldBe(0.03f);
        }
        [Test]
        public void SetPerlinAmplitude_updates_the_PerlinAmplitudeLabel()
        {
            _presenter.SetPerlinAmplitude(3);

            _viewMockery.VerifyPerlinAmplitudeLabelUpdated();
        }
        [Test]
        public void SetPerlinAmplitude_updates_the_NoiseMap()
        {
            _presenter.SetPerlinAmplitude(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinFrequency_updates_the_Model()
        {
            _presenter.SetPerlinFrequency(3);

            _model.PerlinFrequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetPerlinFrequency_updates_the_PerlinFrequencyLabel()
        {
            _presenter.SetPerlinFrequency(3);

            _viewMockery.VerifyPerlinFrequencyLabelUpdated();
        }

        [Test]
        public void SetPerlinFrequency_updates_the_NoiseMap()
        {
            _presenter.SetPerlinFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SelectDefaultNoise_updates_the_NoiseMap()
        {
            _presenter.SelectDefaultNoise();

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SelectDefaultNoise_updates_the_Model()
        {
            _presenter.SelectDefaultNoise();

            _model.SelectedNoiseType.ShouldBe(NoiseType.HorizontalGradient);
        }

        [Test]
        public void SelectDefaultNoise_updates_the_OptionsTab()
        {
            _presenter.SelectDefaultNoise();

            _viewMockery.VerifyDefaultOptionsShown();
        }

        [Test]
        public void SetXOffset_updates_the_NoiseMap()
        {
            _presenter.SetXOffset(1);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetXOffset_updates_the_Model()
        {
            _presenter.SetXOffset(1);

            _model.XOffset.ShouldBe(1);
        }

        [Test]
        public void SetYOffset_updates_the_NoiseMap()
        {
            _presenter.SetYOffset(1);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetYOffset_updates_the_Model()
        {
            _presenter.SetYOffset(1);

            _model.YOffset.ShouldBe(1);
        }

    }
}