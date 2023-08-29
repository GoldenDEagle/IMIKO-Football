﻿using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Progress;
using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Codebase.Gameplay
{
    public class Ball : MonoBehaviour
    {
        private IProgressService _progress;
        private IObjectPool<Ball> _pool;

        public static event Action OnBallCollected;

        private void Awake()
        {
            _progress = ServiceLocator.Container.Single<IProgressService>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>())
            {
                _progress.GameProgress.CurrentScore++;
                OnBallCollected?.Invoke();
                _pool.Release(this);
            }
        }

        public void SetPool(IObjectPool<Ball> pool)
        {
            _pool = pool;
        }
    }
}