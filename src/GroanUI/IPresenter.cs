namespace GroanUI
{
    public interface IPresenter
    {
        void Init();
    }


    public interface IPresenter<in TView> : IPresenter
    {
        void SetView(TView view);
    }

}