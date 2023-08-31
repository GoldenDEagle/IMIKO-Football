using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using System;
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
        private IProgressService _progress;

        private void Awake()
        {
            _ui = ServiceLocator.Container.Single<IUIFactory>();
            _progress = ServiceLocator.Container.Single<IProgressService>();
        }

        private void OnEnable()
        {
            _ui.HUD.OnBackPressed += CloseWindow;

            FillTheBoard();
        }

        private void OnDisable()
        {
            _ui.HUD.OnBackPressed -= CloseWindow;
        }

        private void FillTheBoard()
        {
            foreach (var playerResult in _progress.GameProgress.AllResults)
            {
                var item = _ui.CreateLeaderboardItem();
                item.transform.SetParent(_elementsGroup.transform, false);
                item.ConfigureItem(playerResult);
            }
        }

    }
}