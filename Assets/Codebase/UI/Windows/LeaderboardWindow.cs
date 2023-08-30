using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI.Windows
{
    public class LeaderboardWindow : BaseWindow
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private VerticalLayoutGroup _elementsGroup;

        private IUIFactory _ui;

        private void Awake()
        {
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _ui.HUD.OnBackPressed += CloseWindow;
        }

        private void OnDisable()
        {
            _ui.HUD.OnBackPressed -= CloseWindow;
        }
    }
}