using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Assets;
using Assets.Codebase.Infrastructure.Services.Factories;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using Assets.Codebase.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Codebase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private RectTransform _uiRoot;
        [SerializeField] private HUDController _hud;

        private const string GameSceneName = "Game";

        private void Awake()
        {
            // Register Services
            RegisterServices();

            // Load progress
            ServiceLocator.Container.Single<IProgressService>().LoadProgress();

            // Load scene
            SceneManager.LoadScene(GameSceneName);

            // Show menu
            ServiceLocator.Container.Single<IUIFactory>().CreateMainMenu();
        }

        private void RegisterServices()
        {
            var services = ServiceLocator.Container;

            services.RegisterSingle<IGameStateMachine>(new GameStateMachine());
            services.RegisterSingle<IProgressService>(new ProgressService());
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<IUIFactory>(new UIFactory(_uiRoot, ServiceLocator.Container.Single<IAssetProvider>(), _hud));
            services.RegisterSingle<IBallFactory>(new BallFactory(ServiceLocator.Container.Single<IAssetProvider>()));
        }
    }
}
