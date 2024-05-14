using System;
using System.Collections.Generic;
using Main.Scripts.Work_Flow.States;
using UnityEngine;

namespace Main.Scripts.Work_Flow
{
    public class GameStateMachine : MonoBehaviour, IStateSwitcher
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        private void Awake() => Initialize();

        private void Initialize()
        {
            var data = new StateData(){Switcher = this};
            _states = new Dictionary<Type, IState>()
            {
                {typeof(BootState), new BootState(data)}
            };
            
            SwitchState<BootState>();
        }
        
        public void SwitchState<T>() where T : State
        {
            var state = _states[typeof(T)];
            if((state==null) || (state==_currentState)) return;

            _currentState?.Exit();
            _currentState = state;
            _currentState.Entire();
        }
    }
    
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T:State;
    }
}
