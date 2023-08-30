using Assets.Codebase.Infrastructure.Services;
using Assets.Codebase.Infrastructure.Services.Progress;
using Assets.Codebase.Infrastructure.Services.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI.Windows
{
    public class EndGameWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _ballCount;
        [SerializeField] private TMP_Text _ballsName;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _acceptButton;

        private IUIFactory _ui;
        private IProgressService _progress;

        private void Awake()
        {
            _progress = ServiceLocator.Container.Single<IProgressService>();
            _ui = ServiceLocator.Container.Single<IUIFactory>();
        }
    }
}