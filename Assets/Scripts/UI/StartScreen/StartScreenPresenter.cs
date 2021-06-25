using Utility;

namespace UI.StartScreen
{
    public class StartScreenPresenter : IPresenter
    {
        private readonly StartScreenView _view;
        private readonly Environment _environment;
        private readonly StartScreenData _data;

        public StartScreenPresenter(Environment environment, StartScreenData data, StartScreenView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Detach()
        {
            _data.OnShow -= _view.Show;
            _data.OnHide -= _view.Hide;
        }

        public void Attach()
        {
            _data.OnShow += _view.Show;
            _data.OnHide += _view.Hide;
            _view.start.onClick.AddListener(OnStart);
        }

        private void OnStart()
        {
            _data.Hide();
            _environment.PartsData.Start();
        }
    }
}