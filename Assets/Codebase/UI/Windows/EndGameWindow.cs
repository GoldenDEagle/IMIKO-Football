using Assets.Codebase.Data;
using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI.Windows
{
    public class EndGameWindow : BaseWindow
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _ballCount;
        [SerializeField] private TMP_Text _ballsName;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _acceptButton;

        private IUIFactory _ui;
        private IProgressService _progress;
        private IGameStateMachine _gameStates;

        private void Awake()
        {
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
        }

        private void OnEnable()
        {
            _ballCount.text = _progress.GameProgress.CurrentScore.ToString();

            _acceptButton.onClick.AddListener(SaveResultAndQuit);
            _ui.HUD.OnBackPressed += OnBackPressed;
        }

        private void OnDisable()
        {
            _acceptButton.onClick.RemoveAllListeners();
            _ui.HUD.OnBackPressed -= OnBackPressed;
        }

        private void SaveResultAndQuit()
        {
            // Do nothing without name
            if (_nameInput.text == string.Empty)
                return;

            _progress.GameProgress.AllResults.Add(new PlayerResult(_nameInput.text, _progress.GameProgress.CurrentScore));
            _progress.SaveProgress();

            // disable gamefield and show leaderboard
            _gameStates.SwitchState(GameState.Idle);
            _ui.HUD.SetState(HUDState.Minimal);
            _ui.CreateLeaderboardWindow();
            CloseWindow();
        }

        private void OnBackPressed()
        {
            CloseWindow();
        }
    }
}