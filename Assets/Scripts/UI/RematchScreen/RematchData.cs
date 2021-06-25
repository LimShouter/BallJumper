using System;

namespace UI.RematchScreen
{
    public class RematchData : IScreenData
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