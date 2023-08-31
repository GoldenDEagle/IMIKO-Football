using Assets.Codebase.Infrastructure.Services.Assets;
using Assets.Codebase.UI;
using Assets.Codebase.UI.Windows;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Services.UI
{
    public class UIFactory : IUIFactory
    {
        public HUDController HUD { get; private set; }

        private const string MainMenuPath = "UI/Windows/MainMenuWindow";
        private const string MapSelectionWindowPath = "UI/Windows/MapSelectionWindow";
        private const string EndGameWindowPath = "UI/Windows/EndGameWindow";
        private const string LeaderboardWindowPath = "UI/Windows/LeaderboardWindow";
        private const string PolicyWindowPath = "UI/Windows/PolicyWindow";
        private const string LeaderboardItemPath = "UI/LeaderboardItem";
        
        private RectTransform _uiRoot;
        private IAssetProvider _assets;

        public UIFactory(RectTransform uiRoot, IAssetProvider assets, HUDController hud)
        {
            _uiRoot = uiRoot;
            _assets = assets;
            HUD = hud;
        }

        public MainMenuWindow CreateMainMenu()
        {
            var window = _assets.Instantiate(MainMenuPath).GetComponent<MainMenuWindow>();
            window.transform.SetParent(_uiRoot, false);
            return window;
        }

        public MapSelectionWindow CreateMapSelectionWindow()
        {
            var window = _assets.Instantiate(MapSelectionWindowPath).GetComponent<MapSelectionWindow>();
            window.transform.SetParent(_uiRoot, false);
            return window;
        }

        public EndGameWindow CreateEndGameWindow()
        {
            var window = _assets.Instantiate(EndGameWindowPath).GetComponent<EndGameWindow>();
            window.transform.SetParent(_uiRoot, false);
            return window;
        }

        public LeaderboardWindow CreateLeaderboardWindow()
        {
            var window = _assets.Instantiate(LeaderboardWindowPath).GetComponent<LeaderboardWindow>();
            window.transform.SetParent(_uiRoot, false);
            return window;
        }

        public PolicyWindow CreatePolicyWindow()
        {
            var window = _assets.Instantiate(PolicyWindowPath).GetComponent<PolicyWindow>();
            window.transform.SetParent(_uiRoot, false);
            return window;
        }

        public LeaderboardItem CreateLeaderboardItem()
        {
            var item = _assets.Instantiate(LeaderboardItemPath).GetComponent<LeaderboardItem>();
            return item;
        }
    }
}
