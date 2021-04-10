using System.Drawing;
using GroanUI.Views.Main;
using Moq;
using Shouldly;

namespace GroanUI.Tests
{
    /// <summary>
    /// By there very nature Mock Setup's and Verify's can be quite cumbersome to read,
    /// this "Mockery" acts as a simple wrapper around such Setup's and Verify's
    /// to promote readability and re-use
    /// </summary>
    public class MainViewMockery
    {
        private readonly Mock<IMainView> _viewMock = new();

        public IMainView Object => _viewMock.Object;

        public void SetupChangeEventManagementChecks()
        {
            var disabledCalled = false;
            var enabledCalled = false;
            var sq = new MockSequence();
            _viewMock.Setup(s => s.DisableChangeEvents())
                .Callback(() =>
                {
                    disabledCalled = true;
                    enabledCalled.ShouldBeFalse("Change Events enabled before being disabled in Presenter action");
                });
            _viewMock.InSequence(sq).Setup(s => s.EnableChangeEvents())
                .Callback(() =>
                {
                    enabledCalled = true;
                    disabledCalled.ShouldBeTrue("Change Events were not disabled in Presenter action");
                });
        }

        public void VerifyChangeEventsManaged() 
        {
            var failMessage = $"Value changed events not correctly managed by the Presenter. Surround Presenter actions with calls to {nameof(IMainView.DisableChangeEvents)}() and {nameof(IMainView.EnableChangeEvents)}() to avoid problems caused by cascading 'changed' or 'selected' style events";
            _viewMock.Verify((v)
                => v.DisableChangeEvents(), Times.Exactly(2), failMessage);
            _viewMock.Verify((v)
                => v.EnableChangeEvents(), Times.Exactly(2), failMessage);
        }

        public void VerifyOptionsTabUpdated(NoiseType nt)
        {
            _viewMock.Verify(m
                => m.ShowOptionsTabFor(
                    It.Is<NoiseType>(nt2
                        => nt2 == nt))
            );
        }
        
        public void VerifyNoiseMapImageUpdated()
        {
            _viewMock.VerifySet(m
                => m.NoiseMapImage = It.IsAny<Bitmap>(), Times.Once);
        }
        
        public void VerifySelectedNoiseUpdated(NoiseType nt)
            => _viewMock.VerifySet(m
                => m.SelectedNoise = nt, Times.Once);
        public void VerifyDefaultOptionsShown()
        {
            _viewMock.Verify(m => m.ShowDefaultOptionsTab(), Times.Once);
        }
    }
}