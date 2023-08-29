using Assets.Codebase.UI.Windows;
using Assets.Codebase.UI;
using UnityEngine;
using UnityEditor.VersionControl;
using Assets.Codebase.Infrastructure.Services.Assets;

namespace Assets.Codebase.Infrastructure.Services.UI
{
    public class UIFactory : IUIFactory
    {
        public HUDController HUD { get; private set; }

        private const string MainMenuPath = "UI/Windows/MainMenuWindow";

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
    }
}
