using Assets.Codebase.Data;
using Assets.Codebase.Utils;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Services.Progress
{
    public class ProgressService : IProgressService
    {
        private const string ProgressKey = "Progress";

        private GameProgress _gameProgress;

        public GameProgress GameProgress
        {
            get => _gameProgress;
            set => _gameProgress = value;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, _gameProgress.ToJson());
            PlayerPrefs.Save();
        }

        public GameProgress LoadProgress()
        {
            _gameProgress = PlayerPrefs.GetString(ProgressKey)?.ToDeserealized<GameProgress>() ?? new GameProgress();

            return _gameProgress;
        }
    }
}
