using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Assets;
using Assets.Codebase.Infrastructure.Services.GameStates;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using UnityEngine;

namespace Assets.Codebase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            // Register Services
            RegisterServices();

            // Load progress
            ServiceLocator.Container.Single<IProgressService>().LoadProgress();

            // Load scene
        }

        private void RegisterServices()
        {
            var services = ServiceLocator.Container;

            services.RegisterSingle<IGameStateMachine>(new GameStateMachine());
            services.RegisterSingle<IProgressService>(new ProgressService());
            services.RegisterSingle<IUIFactory>(new UIFactory());
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
        }
    }
}
