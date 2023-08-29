using Assets.Codebase.Gameplay;

namespace Assets.Codebase.Infrastructure.Services.Factories
{
    public interface IBallFactory : IService
    {
        public Ball CreateBall();
    }
}
