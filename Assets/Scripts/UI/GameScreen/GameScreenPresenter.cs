using Utility;

namespace UI.GameScreen
{
    public class GameScreenPresenter : IPresenter
    {
        private readonly GameScreenData _data;
        private readonly GameScreenView _view;

        public GameScreenPresenter(GameScreenData data,GameScreenView view)
        {
            _data = data;
            _view = view;
        }
        public void Attach()
        {
            _data.OnHide += _view.Hide;
            _data.OnShow += _view.Show;
        }

        public void Detach()
        {
            _data.OnHide -= _view.Hide;
            _data.OnShow -= _view.Show;
        }
    }
}