using UnityEngine;

namespace _Recomind.Scripts.Ui.Screens
{
    public abstract class Screen : MonoBehaviour
    {
        public abstract void Show();
        public abstract void Hide();

        public virtual void ShowImmediately() => gameObject.SetActive(true);
        
        public virtual void HideImmediately() => gameObject.SetActive(false);
    }
}