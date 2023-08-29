using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.UI;
using Assets.Codebase.Utils;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private RectTransform _timerField;
        [SerializeField] private Slider _timeSlider;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Image _decorImage;
        [SerializeField] private RectTransform _mobileControls;

        // timer time in seconds
        private float _maxTime = 300f;

        private IGameStateMachine _gameStates;
        private IUIFactory _ui;

        public event Action OnBackPressed;

        private void Awake()
        {
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonPressed);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }

        public void SetState(HUDState state)
        {
            switch (state)
            {
                case HUDState.MainMenu:
                    _backButton.gameObject.SetActive(false);
                    _timerField.gameObject.SetActive(false);
                    _decorImage.gameObject.SetActive(false);
                    _mobileControls.gameObject.SetActive(false);
                    break;
                case HUDState.Minimal:
                    _backButton.gameObject.SetActive(true);
                    _timerField.gameObject.SetActive(false);
                    _decorImage.gameObject.SetActive(false);
                    _mobileControls.gameObject.SetActive(false);
                    break;
                case HUDState.Ingame:
                    _backButton.gameObject.SetActive(true);
                    _timerField.gameObject.SetActive(true);
                    _decorImage.gameObject.SetActive(true);
                    _mobileControls.gameObject.SetActive(true);
                    break;
                default:
                    throw new System.ArgumentException();
            }
        }

        public void SetMaxTime(float value)
        {
            _maxTime = value;
        }

        public void UpdateTimer(float elapsedTime)
        {
            _timeSlider.value = elapsedTime / _maxTime;
            var remainingTime = _maxTime - elapsedTime;
            _timerText.text = TimeConverter.TimeInMinutes(remainingTime);
        }

        private void OnBackButtonPressed()
        {
            OnBackPressed?.Invoke();
            _gameStates.SwitchState(GameState.Idle);
            _ui.CreateMainMenu();
        }
    }
}