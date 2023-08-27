using System;

namespace Assets.Codebase.Infrastructure.Services.GameStates
{
    public interface IGameStateMachine : IService
    {
        public GameState State { get; }

        public event Action<GameState> OnBeforeStateEnter;
        public event Action<GameState> OnAfterStateEnter;

        public void SwitchState(GameState state);
    }
}
