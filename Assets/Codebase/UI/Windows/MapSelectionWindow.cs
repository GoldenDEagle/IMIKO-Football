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
    public class MapSelectionWindow : BaseWindow
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _map1Button;
        [SerializeField] private Button _map2Button;
        [SerializeField] private Button _map3Button;

        private IProgressService _progress;
        private IGameStateMachine _gameStates;
        private IUIFactory _ui;

        private void Awake()
        {
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _gameStates = ServiceLocator.Container.Single<IGameStateMachine>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _ui.HUD.OnBackPressed += CloseWindow;

            _map1Button.onClick.AddListener(() => { ChooseAMap(MapId.Map_1); });
            _map2Button.onClick.AddListener(() => { ChooseAMap(MapId.Map_2); });
            _map3Button.onClick.AddListener(() => { ChooseAMap(MapId.Map_3); });
        }

        private void OnDisable()
        {
            _ui.HUD.OnBackPressed -= CloseWindow;

            _map1Button.onClick.RemoveAllListeners();
            _map2Button.onClick.RemoveAllListeners();
            _map3Button.onClick.RemoveAllListeners();
        }

        private void ChooseAMap(MapId mapId)
        {
            _progress.GameProgress.CurrentMap = mapId;
            _gameStates.SwitchState(GameState.Game);
            CloseWindow();
        }
    }
}