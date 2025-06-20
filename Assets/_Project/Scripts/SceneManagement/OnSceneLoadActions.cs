using UnityEngine;
using UnityEngine.Events;

namespace MightyAdventures.SceneManagement
{
    [DefaultExecutionOrder(-10)]
    public class OnSceneLoadActions : MonoBehaviour
    {
        [SerializeField] private UnityEvent onSceneLoadActions;

        #region MonoBehaviour Methods

        private void Awake()
        {
            onSceneLoadActions?.Invoke();
        }

        #endregion
    }
}