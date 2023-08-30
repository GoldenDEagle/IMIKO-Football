using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Assets;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using Assets.Codebase.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Codebase.Gameplay
{
    public class GameController : MonoBehaviour
    {
        private const string PlayerPrefabPath = "Gameplay/Player";

        [Tooltip("Duration of game in seconds")]
        [SerializeField] private float _gameTime = 300f;
        [SerializeField] private int _numberOfBallsInGame = 3;
        [SerializeField] private List<Map> _maps;

        private IGameStateMachine _gameStates;
        private IProgressService _progress;
        private IUIFactory _ui;
        private IAssetProvider _assets;

        private Map _activeMap;
        private PlayerController _activePlayer;
        private Coroutine _timerRoutine;
        private float _elapsedTime = 0f;
        private WaitForSeconds _oneSecondStep = new WaitForSeconds(1f);

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
            _assets = ServiceLocator.Container.Single<IAssetProvider>();

            // Configure hud with game timer
            _ui.HUD.SetMaxTime(_gameTime);
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
            if (newState == GameState.Idle)
            {
                ClearGameField();
            }
        }

        private void StartGame()
        {
            // Reset stats
            _progress.GameProgress.CurrentScore = 0;
            _elapsedTime = 0;

            // Choose map
            _activeMap = _maps.FirstOrDefault(x => x.Id == _progress.GameProgress.CurrentMap);
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
            _timerRoutine = StartCoroutine(CountTime());
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
            if (_gameStates.State == GameState.Game || _gameStates.State == GameState.EndGame)
            {
                _gameStates.SwitchState(GameState.Idle);
            }
        }

        private void ClearGameField()
        {
            Pool.Instance.BallPool.Dispose();
            Destroy(_activePlayer.gameObject);
            _activePlayer = null;
            _activeMap.gameObject.SetActive(false);
            _activeMap = null;
            if (_timerRoutine != null)
            {
                StopCoroutine(_timerRoutine);
                _timerRoutine = null;
            }
        }

        private IEnumerator CountTime()
        {
            _elapsedTime = 0f;

            while (_elapsedTime < _gameTime)
            {
                _ui.HUD.UpdateTimer(_elapsedTime);
                _elapsedTime++;
                yield return _oneSecondStep;
            }

            EndGame();
        }

        private void EndGame()
        {
            _gameStates.SwitchState(GameState.EndGame);
            _activePlayer.DisableInput();
            _ui.CreateEndGameWindow();
        }
    }
}
