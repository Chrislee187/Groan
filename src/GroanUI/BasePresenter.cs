namespace GroanUI
{
    public abstract class BasePresenter<TView> : IPresenter<TView>
    {
        protected TView View;

        public virtual void SetView(TView view) => View = view;
        public abstract void Init();
    }
}