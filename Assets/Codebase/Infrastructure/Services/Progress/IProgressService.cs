using Assets.Codebase.Data;

namespace Assets.Codebase.Infrastructure.Services.Progress
{
    public interface IProgressService : IService
    {
        public GameProgress GameProgress { get; set; }

        public void SaveProgress();
        public GameProgress LoadProgress();
    }
}
