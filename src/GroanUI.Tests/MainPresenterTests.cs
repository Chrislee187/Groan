using System.Drawing;
using NUnit.Framework;
using Shouldly;

namespace GroanUI.Tests
{
    public class MainPresenterTests
    {
        private MainPresenter _presenter;
        private MainViewMockery _viewMockery;
        private MainModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new MainModelBuilder().Build();
            _model.MapSize = new Size(1, 1);
            _viewMockery = new MainViewMockery();

            _presenter = new MainPresenter(_model);
            _presenter.SetView(_viewMockery.Object);
            _presenter.Init();

            _viewMockery.SetupVerifyEventsDisabled();
        }

        [TearDown]
        public void TearDown()
        {
            _viewMockery.VerifyEventsDisabled();
        }

        [Test]
        public void NoiseTypeSelected_updates_the_selected_OptionsTab()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);
            
            _viewMockery.OptionsTabUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void NoiseTypeSelected_updates_the_NoiseMap()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);

            _viewMockery.NoiseMapImageUpdated();
        }

        [Test]
        public void NoiseTypeSelected_updates_the_Model()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_Model()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_selected_NoiseType()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _viewMockery.SelectedNoiseUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTabSelected_updates_the_NoiseMap()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _viewMockery.NoiseMapImageUpdated();
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

            _viewMockery.NoiseMapImageUpdated();
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

            _viewMockery.MinThresholdLabelUpdated();
        }

        [Test]
        public void SetMinThreshold_updates_the_NoiseMap()
        {
            _presenter.SetMinThreshold(500);

            _viewMockery.NoiseMapImageUpdated();
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

            _viewMockery.MaxThresholdLabelUpdated();
        }
        [Test]
        public void SetMaxThreshold_updates_the_NoiseMap()
        {
            _presenter.SetMaxThreshold(500);

            _viewMockery.NoiseMapImageUpdated();
        }
    }
}