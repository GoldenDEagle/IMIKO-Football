using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Codebase.Gameplay
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }

        public void OnUpPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SetVerticalDirection(1f);
            }

            if (context.canceled)
            {
                _playerController.SetVerticalDirection(0f);
            }
        }

        public void OnDownPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SetVerticalDirection(-1f);
            }

            if (context.canceled)
            {
                _playerController.SetVerticalDirection(0f);
            }
        }

        public void OnLeftPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SetHorizontalDirection(-1f);
            }

            if (context.canceled)
            {
                _playerController.SetHorizontalDirection(0f);
            }
        }

        public void OnRightPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _playerController.SetHorizontalDirection(1f);
            }

            if (context.canceled)
            {
                _playerController.SetHorizontalDirection(0f);
            }
        }
    }
}