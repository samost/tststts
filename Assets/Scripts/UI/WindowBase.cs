using UnityEngine;

namespace UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public virtual void Show()
        {
            this.gameObject.SetActive(true);
            Debug.Log("Show window:" + GetType().Name);
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
            Debug.Log("Hide window:" + GetType().Name);
        }
    }
}