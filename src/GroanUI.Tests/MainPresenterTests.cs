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

        [Test]
        public void NoiseTypeSelected_updates_the_selected_OptionsTab()
        {
            _presenter.SelectNoiseType(NoiseType.Cylinder);
            
            _viewMockery.VerifyOptionsTabUpdated(NoiseType.Cylinder);
        }

        [Test]
        public void NoiseTypeSelected_updates_the_NoiseMap()
        {
            _presenter.SelectNoiseType(NoiseType.Cylinder);
            
            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void NoiseTypeSelected_updates_the_Model()
        {
            _presenter.SelectNoiseType(NoiseType.Cylinder);
            
            _model.SelectedNoiseType.ShouldBe(NoiseType.Cylinder);
        }

        [Test]
        public void OptionsTabSelected_updates_the_Model()
        {
            _presenter.SelectOptionsTab(NoiseType.Cylinder);
            
            _model.SelectedNoiseType.ShouldBe(NoiseType.Cylinder);
        }

        [Test]
        public void OptionsTabSelected_updates_the_selected_NoiseType()
        {
            _presenter.SelectOptionsTab(NoiseType.Cylinder);
            
            _viewMockery.VerifySelectedNoiseUpdated(NoiseType.Cylinder);
        }

        [Test]
        public void OptionsTabSelected_updates_the_NoiseMap()
        {
            _presenter.SelectOptionsTab(NoiseType.Cylinder);
            
            _viewMockery.VerifyNoiseMapImageUpdated();
        }



        [Test]
        public void SetPerlinLacunarity_updates_the_Mode()
        {
            _presenter.UpdatePerlinLacunarity(3);

            _model.PerlinLacunarity.ShouldBe(3);
        }

        [Test]
        public void SetPerlinLacunarity_updates_the_NoiseMap()
        {
            _presenter.UpdatePerlinLacunarity(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinFrequency_updates_the_Model()
        {
            _presenter.UpdatePerlinFrequency(0.03f);

            _model.PerlinFrequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetPerlinFrequency_updates_the_NoiseMap()
        {
            _presenter.UpdatePerlinFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinOctaves_updates_the_Model()
        {
            _presenter.UpdatePerlinOctaves(2);

            _model.PerlinOctaves.ShouldBe(2);
        }

        [Test]
        public void SetPerlinOctaves_updates_the_NoiseMap()
        {
            _presenter.UpdatePerlinOctaves(2);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetPerlinPersistance_updates_the_Model()
        {
            _presenter.UpdatePerlinPersistance(1.5f);

            _model.PerlinPersistance.ShouldBe(1.5f);
        }

        [Test]
        public void SetPerlinPersistance_updates_the_NoiseMap()
        {
            _presenter.UpdatePerlinPersistance(1.5f);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }


        [Test]
        public void SetBillowLacunarity_updates_the_Mode()
        {
            _presenter.UpdateBillowLacunarity(3);

            _model.BillowLacunarity.ShouldBe(3);
        }

        [Test]
        public void SetBillowLacunarity_updates_the_NoiseMap()
        {
            _presenter.UpdateBillowLacunarity(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetBillowFrequency_updates_the_Model()
        {
            _presenter.UpdateBillowFrequency(0.03f);

            _model.BillowFrequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetBillowFrequency_updates_the_NoiseMap()
        {
            _presenter.UpdateBillowFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetBillowOctaves_updates_the_Model()
        {
            _presenter.UpdateBillowOctaves(2);

            _model.BillowOctaves.ShouldBe(2);
        }

        [Test]
        public void SetBillowOctaves_updates_the_NoiseMap()
        {
            _presenter.UpdateBillowOctaves(2);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetBillowPersistance_updates_the_Model()
        {
            _presenter.UpdateBillowPersistance(1.5f);

            _model.BillowPersistance.ShouldBe(1.5f);
        }

        [Test]
        public void SetBillowPersistance_updates_the_NoiseMap()
        {
            _presenter.UpdateBillowPersistance(1.5f);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }


        [Test]
        public void SetCylinderFrequency_updates_the_Model()
        {
            _presenter.UpdateCylinderFrequency(0.03f);

            _model.CylinderFrequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetCylinderFrequency_updates_the_NoiseMap()
        {
            _presenter.UpdateCylinderFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void InvertNoise_updates_the_model()
        {
            _model.Invert.ShouldBeFalse();

            _presenter.SetInverted(true);

            _model.Invert.ShouldBeTrue();
        }

        [Test]
        public void InvertNoise_updates_the_NoiseMap()
        {
            _presenter.SetInverted(true);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void RoundToggle_updates_the_model()
        {
            _model.Round.ShouldBeFalse();

            _presenter.SetRounded(true);

            _model.Round.ShouldBeTrue();
        }

        [Test]
        public void RoundToggle_updates_the_NoiseMap()
        {
            _presenter.SetRounded(true);

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
            
            _model.SelectedNoiseType.ShouldBe(NoiseType.Perlin);
        }

        [Test]
        public void SelectDefaultNoise_updates_the_OptionsTab()
        {
            _presenter.SelectDefaultNoise();

            _viewMockery.VerifyDefaultOptionsShown();
        }



    }
}