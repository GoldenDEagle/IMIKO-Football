using System;

namespace Assets.Codebase.Infrastructure.Services.GameStates
{
    public class GameStateMachine : IGameStateMachine
    {
        private GameState _state = GameState.Idle;
        public GameState State => _state;

        public event Action<GameState> OnBeforeStateEnter;
        public event Action<GameState> OnAfterStateEnter;

        public void SwitchState(GameState newState)
        {
            OnBeforeStateEnter?.Invoke(newState);

            _state = newState;

            OnAfterStateEnter?.Invoke(newState);
        }
    }
}
