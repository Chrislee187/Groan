using System.Drawing;
using GroanUI.Plotters;
using GroanUI.Views.Main;
using Moq;
using NUnit.Framework;

namespace GroanUI.Tests
{
    public class MainPresenterTestBase
    {
        protected MainPresenter Presenter;

        protected MainViewMockery ViewMockery;

        protected MainModel Model;


        [SetUp]
        public void Setup()
        {
            Model = new MainModelBuilder().Build();
            Model.MapSize = new Size(1, 1);
            ViewMockery = new MainViewMockery();
            Presenter = new MainPresenter(Model, new Mock<INoiseFactory>().Object, 0);
            Presenter.SetView(ViewMockery.Object);
            Presenter.Init();

            ViewMockery.SetupChangeEventManagementChecks();
        }

        [TearDown]
        public void TearDown()
        {
            ViewMockery.VerifyChangeEventsManaged();
        }
    }
}