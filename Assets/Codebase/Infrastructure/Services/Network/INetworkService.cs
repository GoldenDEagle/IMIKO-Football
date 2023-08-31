namespace Assets.Codebase.Infrastructure.Services.Network
{
    public interface INetworkService : IService
    {
        public void UpdatePolicy();
        public string GetPolicy();
    }
}
