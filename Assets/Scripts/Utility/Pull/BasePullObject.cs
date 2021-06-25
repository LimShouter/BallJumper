using UnityEngine;

namespace Utility.Pull
{
    public class BasePullObject : MonoBehaviour, IPullObject
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}