using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Codebase.Gameplay
{
    public class Ball : MonoBehaviour
    {
        private IProgressService _progress;
        private IGameStateMachine _gameStates;
        private IObjectPool<Ball> _pool;

        public static event Action OnBallCollected;

        private void Awake()
        {
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
        }

        private void OnEnable()
        {
            _gameStates.OnAfterStateEnter += OnGameStateChanged;
        }

        private void OnDisable()
        {
            _gameStates.OnAfterStateEnter -= OnGameStateChanged;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Actions on player collision
            if (collision.GetComponent<PlayerController>())
            {
                _progress.GameProgress.CurrentScore++;
                OnBallCollected?.Invoke();
                _pool.Release(this);
            }
        }

        private void OnGameStateChanged(GameState newState)
        {
            // disable when game becomes idle
            if (newState != GameState.Idle)
                return;

            _pool.Release(this);
        }

        public void SetPool(IObjectPool<Ball> pool)
        {
            _pool = pool;
        }
    }
}