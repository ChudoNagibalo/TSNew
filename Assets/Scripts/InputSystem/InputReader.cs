using FPGame.InputSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace FPGame
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, InputActionsMap.IPlayerActions, InputActionsMap.IUIActions
    {
        private InputActionsMap m_inputActionsMap;

        public event Action<Vector2> MovementEvent;
        public event Action JumpEvent;
        public event Action JumpCancelledEvent;
        public event Action PauseEvent;
        public event Action ResumeEvent;
        public event Action InteractEvent;
        public event Action AttackEvent;

        private void OnEnable()
        {
            if(m_inputActionsMap == null)
            {
                m_inputActionsMap = new InputActionsMap();

                m_inputActionsMap.Player.SetCallbacks(this);
                m_inputActionsMap.UI.SetCallbacks(this);

                SetPlayer();
            }
        }

        public void SetPlayer()
        {
            m_inputActionsMap.Player.Enable();
            m_inputActionsMap.UI.Disable();
        }

        public void SetUI()
        {
            m_inputActionsMap.UI.Enable();
            m_inputActionsMap.Player.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
                JumpEvent?.Invoke();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();
                SetUI();
            }
        }

        public void OnResume(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                ResumeEvent?.Invoke();
                SetPlayer();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                InteractEvent?.Invoke();
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                AttackEvent?.Invoke();
            }
        }
    }
}

