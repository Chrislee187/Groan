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
        public void NoiseType_updates_the_selected_OptionsTab()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);
            
            _viewMockery.OptionsTabUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void NoiseType_updates_the_NoiseMap()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);

            _viewMockery.NoiseMapImageUpdated();
        }

        [Test]
        public void NoiseType_updates_the_Model()
        {
            _presenter.NoiseTypeSelected(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTab_updates_the_selected_NoiseType()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _viewMockery.SelectedNoiseUpdated(NoiseType.VerticalGradient);
        }

        [Test]
        public void OptionsTab_updates_the_NoiseMap()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _viewMockery.NoiseMapImageUpdated();
        }

        [Test]
        public void OptionsTab_updates_the_Model()
        {
            _presenter.OptionsTabSelected(NoiseType.VerticalGradient);

            _model.SelectedNoiseType.ShouldBe(NoiseType.VerticalGradient);
        }

        [Test]
        public void Invert_updates_the_model()
        {
            _model.InvertMap.ShouldBeFalse();

            _presenter.InvertNoise();

            _model.InvertMap.ShouldBeTrue();
        }

        [Test]
        public void Invert_updates_the_NoiseMap()
        {
            _presenter.InvertNoise();

            _viewMockery.NoiseMapImageUpdated();
        }
    }
}