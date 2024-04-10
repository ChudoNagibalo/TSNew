using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPGame
{
    public class StateMachine
    {
        Dictionary<Type,State> _states = new Dictionary<Type,State>();
        public State CurrentState { get;  set; }

        public void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void ChangeState <T>() where T : State
        {
            var type = typeof(T);
            if (CurrentState != null && CurrentState.GetType() == type)
                return;

            if(_states.TryGetValue(type, out State newState))
            {
                CurrentState?.ExitState();
                CurrentState = newState;
                CurrentState.EnterState();
            }
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }

    }
}
