using Utility;

namespace UI.RematchScreen
{
    public class RematchPresenter : IPresenter
    {
        private readonly RematchView _view;
        private readonly Environment _environment;
        private readonly RematchData _data;

        public RematchPresenter(Environment environment, RematchData data, RematchView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Detach()
        {
            _data.OnShow -= OnShow;
            _data.OnHide -= OnHide;
            _view.rematch.onClick.RemoveListener(OnRematch);
            _view.startScreen.onClick.RemoveListener(OnStartScreen);
        }

        public void Attach()
        {
            _data.OnShow += OnShow;
            _data.OnHide += OnHide;
            _view.rematch.onClick.AddListener(OnRematch);
            _view.startScreen.onClick.AddListener(OnStartScreen);
        }

        private void OnStartScreen()
        {
            _data.Hide();
            _environment.StartScreenData.Show();
        }

        private void OnRematch()
        {
            _data.Hide();
            _environment.PartsData.Start();
        }

        private void OnHide()
        {
            _view.root.SetActive(false);
        }

        private void OnShow()
        {
            _view.root.SetActive(true);
        }
    }
}