using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.UI;
using TMPro;
using UnityEngine;

namespace Assets.Codebase.UI.Windows
{
    public class PolicyWindow : BaseWindow
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _policyText;

        private IUIFactory _ui;

        private void Awake()
        {
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }

        private void OnEnable()
        {
            _ui.HUD.OnBackPressed += CloseWindow;

            // Get policies
        }

        private void OnDisable()
        {
            _ui.HUD.OnBackPressed -= CloseWindow;
        }
    }
}