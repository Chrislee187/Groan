namespace GroanUI.Views
{
    public abstract class BasePresenter<TView>
    {
        protected TView View;

        public void SetView(TView view) => View = view;
        public abstract void Init();
    }
}