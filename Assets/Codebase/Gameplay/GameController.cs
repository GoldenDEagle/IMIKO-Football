using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private List<Map> _maps;

        private IGameStateMachine _gameStates;
        private IProgressService _progress;
        private IUIFactory _ui;

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _gameStates.OnAfterStateEnter += OnAfterGameStateChanged;
        }

        private void OnDisable()
        {
            _gameStates.OnAfterStateEnter -= OnAfterGameStateChanged;
        }

        private void OnAfterGameStateChanged(GameState newState)
        {
            if (newState == GameState.Game)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            // Enable Hud

            // Spawn Player

            // Spawn Balls

            // Start Timer
        }
    }
}
