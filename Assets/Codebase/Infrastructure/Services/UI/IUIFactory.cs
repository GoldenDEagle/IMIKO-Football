using Assets.Codebase.UI;
using Assets.Codebase.UI.Windows;

namespace Assets.Codebase.Infrastructure.Services.UI
{
    public interface IUIFactory : IService
    {
        public HUDController HUD { get; }

        public MainMenuWindow CreateMainMenu();
        public MapSelectionWindow CreateMapSelectionWindow();
        public EndGameWindow CreateEndGameWindow();
    }
}
