using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Factories;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Codebase.Gameplay
{
    public class Pool : MonoBehaviour
    {
        private ObjectPool<Ball> _ballPool;
        private IBallFactory _ballFactory;

        public ObjectPool<Ball> BallPool => _ballPool;

        public static Pool Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _ballFactory = ServiceLocator.Container.Single<IBallFactory>();
        }

        private void Start()
        {
            _ballPool = new ObjectPool<Ball>(CreateBall, OnGetBall, OnReleaseBall, OnBallDestroy);
        }

        private Ball CreateBall()
        {
            var ball = _ballFactory.CreateBall();
            ball.SetPool(_ballPool);
            ball.transform.SetParent(this.transform, true);
            return ball;
        }

        private void OnGetBall(Ball ball)
        {
            
        }

        private void OnReleaseBall(Ball ball)
        {
            ball.gameObject.SetActive(false);
        }

        private void OnBallDestroy(Ball ball)
        {
            Destroy(ball.gameObject);
        }
    }
}