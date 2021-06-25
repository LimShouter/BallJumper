using UnityEngine;
using UnityEngine.UI;

namespace UI.RematchScreen
{
    public class RematchView : MonoBehaviour,IScreenView
    {
        public GameObject root;

        public Button rematch;
        public Button startScreen;
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