using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Assets;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using Assets.Codebase.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Gameplay
{
    public class GameController : MonoBehaviour
    {
        private const string PlayerPrefabPath = "Gameplay/Player";

        [SerializeField] private int _numberOfBallsInGame = 3;
        [SerializeField] private List<Map> _maps;

        private IGameStateMachine _gameStates;
        private IProgressService _progress;
        private IUIFactory _ui;
        private IAssetProvider _assets;

        private Map _activeMap;
        private PlayerController _activePlayer;

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
            _assets = ServiceLocator.Container.Single<IAssetProvider>();
        }

        private void OnEnable()
        {
            _gameStates.OnAfterStateEnter += OnAfterGameStateChanged;
            Ball.OnBallCollected += SpawnABall;
            _ui.HUD.OnBackPressed += AbandonGame;
        }

        private void OnDisable()
        {
            _gameStates.OnAfterStateEnter -= OnAfterGameStateChanged;
            Ball.OnBallCollected -= SpawnABall;
            _ui.HUD.OnBackPressed -= AbandonGame;
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
            // reset score
            _progress.GameProgress.CurrentScore = 0;
            _activeMap = _maps[0];
            _activeMap.gameObject.SetActive(true);

            // Enable Hud
            _ui.HUD.SetState(HUDState.Ingame);

            // Spawn Player
            _activePlayer = _assets.Instantiate(PlayerPrefabPath).GetComponent<PlayerController>();
            _activePlayer.transform.position = _activeMap.PlayerSpawnPosition.position;

            // Spawn Balls
            for (int i = 0; i < _numberOfBallsInGame; i++)
            {
                SpawnABall();
            }

            // Start Timer
        }

        private void SpawnABall()
        {
            int randomIndex = Random.Range(0, _activeMap.BallSpawnPositions.Count);
            var ball = Pool.Instance.BallPool.Get();
            ball.transform.position = _activeMap.BallSpawnPositions[randomIndex].position;
            ball.gameObject.SetActive(true);
        }

        private void AbandonGame()
        {
            Pool.Instance.BallPool.Dispose();
            Destroy(_activePlayer.gameObject);
            _activePlayer = null;
            _activeMap.gameObject.SetActive(false);
            _activeMap = null;
        }
    }
}
