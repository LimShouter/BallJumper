using System;

namespace UI.GameScreen
{
    public class GameScreenData : IScreenData
    {
        public event Action OnHide;
        public event Action OnShow;
        
        public void Hide()
        {
            OnHide?.Invoke();
        }

        public void Show()
        {
            OnShow?.Invoke();
        }
    }
}