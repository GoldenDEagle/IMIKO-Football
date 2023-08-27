using Assets.Codebase.Infrastructure.Services;
using UnityEngine;

namespace Assets.Codebase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            RegisterServices();
            
            // Load progress

            // Load scene
        }

        private void RegisterServices()
        {
            var services = ServiceLocator.Container;
        }
    }
}
