using UnityEngine;

namespace MightyAdventures.UIScreens
{
    public abstract class AbstractUIScreen : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        public void Show()
        {
            canvas.enabled = true;
        }

        protected void Hide()
        {
            canvas.enabled = false;
        }

        #region MonoBehaviour Methods

        protected virtual void Awake()
        {
            Hide();
        }

        #endregion
    }
}