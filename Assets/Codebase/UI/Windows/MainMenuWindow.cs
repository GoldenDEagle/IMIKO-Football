using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _resultsButton;
        [SerializeField] private Button _policyButton;
        [SerializeField] private Button _quitButton;

        // remove later
        private IGameStateMachine _gameStates;

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        { 
            _startButton.onClick.RemoveListener(StartGame);
            _quitButton.onClick.RemoveListener(QuitGame);
        }

        private void StartGame()
        {
            _gameStates.SwitchState(GameState.Game);
            CloseWindow();
        }

        private void CloseWindow()
        {
            Destroy(gameObject);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}