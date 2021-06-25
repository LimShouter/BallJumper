using System;
using Utility;

namespace UI
{
    public interface IScreenData : IData
    {
        event Action OnHide;
        event Action OnShow;

        void Hide();
        void Show();
    }
}