using UnityEngine;
using UnityEngine.UI;

namespace UI.StartScreen
{
    public class StartScreenView : MonoBehaviour,IScreenView
    {
        public Button start;
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