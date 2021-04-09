using System;
using System.Linq;
using GroanUI.Views.Main;
using NUnit.Framework;
using Shouldly;

namespace GroanUI.Tests
{
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