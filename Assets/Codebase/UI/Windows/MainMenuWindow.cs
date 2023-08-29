﻿using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI.Windows
{
    public class MainMenuWindow : BaseWindow
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _resultsButton;
        [SerializeField] private Button _policyButton;
        [SerializeField] private Button _quitButton;

        private IUIFactory _ui;
        // remove later
        private IGameStateMachine _gameStates;

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _ui.HUD.SetState(HUDState.MainMenu);

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
            _ui.HUD.SetState(HUDState.Minimal);
            _ui.CreateMapSelectionWindow();
            CloseWindow();
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}