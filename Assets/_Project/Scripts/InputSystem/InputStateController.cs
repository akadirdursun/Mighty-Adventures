using UnityEngine;

namespace MightyAdventures.InputSystem
{
    public class InputStateController : MonoBehaviour
    {
        [SerializeField] private PlayerInputs playerInputs;

        public void EnableGameplayInputs()
        {
            playerInputs.GameplayActions.Enable();
        }

        public void DisableGameplayInputs()
        {
            playerInputs.GameplayActions.Disable();
        }
    }
}