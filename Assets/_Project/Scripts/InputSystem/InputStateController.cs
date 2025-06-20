using UnityEngine;

namespace MightyAdventures.InputSystem
{
    public class InputStateController : MonoBehaviour
    {
        [SerializeField] private PlayerInputs playerInputs;

        #region MonoBehaviour Methods

        private void Start()
        {
            playerInputs.EnableGameplayInputs();
        }

        #endregion
    }
}