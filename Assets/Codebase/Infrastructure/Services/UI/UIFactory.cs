using UnityEngine;

namespace Assets.Codebase.Infrastructure.Services.UI
{
    public class UIFactory : IUIFactory
    {
        private RectTransform _uiRoot;

        public UIFactory(RectTransform uiRoot)
        {
            _uiRoot = uiRoot;
        }
    }
}
