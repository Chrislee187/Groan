using System;
using System.Drawing;
using Moq;
using Shouldly;

namespace GroanUI.Tests
{
    public class MainViewMockery
    {
        private readonly Mock<IMainView> _viewMock = new();

        public IMainView Object => _viewMock.Object;

        public void SetupVerifyEventsDisabled()
        {
            var disabledCalled = false;
            var enabledCalled = false;
            var sq = new MockSequence();
            _viewMock.Setup(s => s.DisableChangeEvents())
                .Callback(() =>
                {
                    disabledCalled = true;
                    enabledCalled.ShouldBeFalse();
                });
            _viewMock.InSequence(sq).Setup(s => s.EnableChangeEvents())
                .Callback(() =>
                {
                    enabledCalled = true;
                    disabledCalled.ShouldBeTrue();
                });
        }

        public void VerifyEventsDisabled() 
        { 
            _viewMock.Verify((v)
                => v.DisableChangeEvents(), Times.Once);
            _viewMock.Verify((v)
                => v.EnableChangeEvents(), Times.Once);
        }

        public void OptionsTabUpdated(NoiseType nt)
        {
            _viewMock.Verify(m
                => m.ShowOptionsTabFor(
                    It.Is<NoiseType>(nt2
                        => nt2 == nt))
            );
        }
        public void MinThresholdLabelUpdated() =>
            _viewMock.VerifySet(m
                => m.MinThresholdLabel = It.IsAny<float>(), Times.Once);
        public void MaxThresholdLabelUpdated() =>
            _viewMock.VerifySet(m
                => m.MaxThresholdLabel = It.IsAny<float>(), Times.Once);

        public void NoiseMapImageUpdated() =>
            _viewMock.VerifySet(m
                => m.NoiseMapImage = It.IsAny<Bitmap>(), Times.Once);

        public void SelectedNoiseUpdated(NoiseType nt)
            => _viewMock.VerifySet(m
                => m.SelectedNoise = nt, Times.Once);

        public void VerifyAll()
        {
            
            _viewMock.VerifyAll();
        }
    }
}