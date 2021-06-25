using UI.GameScreen.ScoreManager;
using UnityEngine;

namespace UI.GameScreen
{
    public class GameScreenView : MonoBehaviour, IScreenView
    {
        public ScoreView scoreView;
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}