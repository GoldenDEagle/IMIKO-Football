using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Network;
using Assets.Codebase.Infrastructure.Services.UI;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Codebase.UI.Windows
{
    public class PolicyWindow : BaseWindow
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _policyText;

        private IUIFactory _ui;
        private INetworkService _network;

        private void Awake()
        {
            _ui = ServiceLocator.Container.Single<IUIFactory>();
            _network = ServiceLocator.Container.Single<INetworkService>();
        }

        private void OnEnable()
        {
            _ui.HUD.OnBackPressed += CloseWindow;

            // Get policies
            _policyText.text = _network.GetPolicy();
        }

        private void OnDisable()
        {
            _ui.HUD.OnBackPressed -= CloseWindow;
        }
    }
}