using System;
using System.Drawing;
using System.Linq;
using GroanUI.Plotters;
using GroanUI.Views.Main;
using Moq;
using NUnit.Framework;
using SharpNoise;
using SharpNoise.Modules;
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
        public void SetPerlinQuality_updates_the_Model()
        {
            _presenter.SelectPerlinQuality(NoiseQuality.Fast);

            _model.PerlinQuality.ShouldBe(NoiseQuality.Fast);
        }

        
        [Test]
        public void SetPerlinQuality_updates_the_NoiseMap()
        {
            _presenter.SelectPerlinQuality(NoiseQuality.Fast);

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
        public void SetBillowQuality_updates_the_Model()
        {
            _presenter.SelectBillowQuality(NoiseQuality.Fast);

            _model.BillowQuality.ShouldBe(NoiseQuality.Fast);
        }


        [Test]
        public void SetBillowQuality_updates_the_NoiseMap()
        {
            _presenter.SelectBillowQuality(NoiseQuality.Fast);

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
        public void SetCellFrequency_updates_the_Model()
        {
            _presenter.UpdateCellFrequency(0.03f);

            _model.CellFrequency.ShouldBe(0.03f);
        }

        [Test]
        public void SetCellFrequency_updates_the_NoiseMap()
        {
            _presenter.UpdateCellFrequency(3);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }

        [Test]
        public void SetCellType_updates_the_Model()
        {
            _presenter.SelectCellType(Cell.CellType.Quadratic);

            _model.CellType.ShouldBe(Cell.CellType.Quadratic);
        }
        [Test]
        public void SetCellType_updates_the_NoiseMap()
        {
            _presenter.SelectCellType(Cell.CellType.Quadratic);

            _viewMockery.VerifyNoiseMapImageUpdated();
        }
        [Test]
        public void SetCellDisplacement_updates_the_Model()
        {
            _presenter.UpdateCellDisplacement(0.03f);

            _model.CellDisplacement.ShouldBe(0.03f);
        }

        [Test]
        public void SetCellDisplacement_updates_the_NoiseMap()
        {
            _presenter.UpdateCellDisplacement(3);

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
    [TestFixture]
    public class MainModelTests
    {
        private MainModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new MainModelBuilder().Build();

        }

        [Test]
        public void DefaultModel_contains_all_slider_setups()
        {
            Enum.GetValues<Sliders>()
                .All(s => _model.SliderSetups.Any(setup => setup.Slider == s))
                .ShouldBeTrue();
        }
    }

}