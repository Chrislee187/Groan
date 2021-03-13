using System.Drawing;
using System.Threading;
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

        public void VerifyOptionsTabUpdated(NoiseType nt)
        {
            _viewMock.Verify(m
                => m.ShowOptionsTabFor(
                    It.Is<NoiseType>(nt2
                        => nt2 == nt))
            );
        }
        public void VerifyMinThresholdLabelUpdated() =>
            _viewMock.VerifySet(m
                => m.MinThresholdLabel = It.IsAny<float>(), Times.Once);
        public void VerifyMaxThresholdLabelUpdated() =>
            _viewMock.VerifySet(m
                => m.MaxThresholdLabel = It.IsAny<float>(), Times.Once);

        public void VerifyNoiseMapImageUpdated()
        {
            // NOTE: Image updates are delayed briefly stop the bitmap creation
            // process triggering over and over when draggin sliders.
            // Thread.Sleep((int) (MainPresenter.MapRefreshDelayMs + 25));
            _viewMock.VerifySet(m
                => m.NoiseMapImage = It.IsAny<Bitmap>(), Times.Once);
        }

        public void VerifySelectedNoiseUpdated(NoiseType nt)
            => _viewMock.VerifySet(m
                => m.SelectedNoise = nt, Times.Once);
    }
}