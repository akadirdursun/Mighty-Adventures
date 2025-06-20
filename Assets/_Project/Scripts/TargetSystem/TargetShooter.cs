using MightyAdventures.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MightyAdventures.TargetSystem
{
    public class TargetShooter : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;
        [SerializeField] private PlayerInputs playerInputs;

        private void OnPlayerClicked(InputAction.CallbackContext obj)
        {
            var clickPos = Input.mousePosition;
            var ray = targetCamera.ScreenPointToRay(clickPos);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo)) return;
            if (!hitInfo.collider.TryGetComponent(out AbstractTarget target)) return;
            target.OnHit();
        }

        #region MonoBehavior Methods

        private void Awake()
        {
            targetCamera ??= Camera.main;
        }

        private void OnEnable()
        {
            playerInputs.GameplayActions.ClickAction.performed += OnPlayerClicked;
        }

        private void OnDisable()
        {
            playerInputs.GameplayActions.ClickAction.performed -= OnPlayerClicked;
        }

        #endregion
    }
}