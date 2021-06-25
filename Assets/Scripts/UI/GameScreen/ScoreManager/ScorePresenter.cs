using Utility;

namespace UI.GameScreen.ScoreManager
{
    public class ScorePresenter : IPresenter
    {
        private readonly ScoreView _view;
        private readonly ScoreData _data;

        public ScorePresenter(ScoreData data, ScoreView view)
        {
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _data.OnAddScore += AddScore;
            _data.OnRefresh += Refresh;
        }

        public void Detach()
        {
            _data.OnAddScore -= AddScore;
            _data.OnRefresh -= Refresh;
        }

        private void Refresh()
        {
            _data.Score = 0;
            _view.score.text = _data.Score.ToString();
            _view.maxScore.text = _data.MaxScore.ToString();
        }

        private void AddScore(int obj)
        {
            _data.Score += obj;
            _view.score.text = _data.Score.ToString();
            if (_data.Score > _data.MaxScore)
            {
                _data.MaxScore = _data.Score;
                _view.maxScore.text = _data.MaxScore.ToString();
            }
        }
    }
}