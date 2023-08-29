using Assets.Codebase.Gameplay;
using Assets.Codebase.Infrastructure.Services.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Codebase.Infrastructure.Services.Factories
{
    public class BallFactory : IBallFactory
    {
        private const string BallPrefabPath = "Gameplay/Ball";

        private IAssetProvider _assets;

        public BallFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public Ball CreateBall()
        {
            var ball = _assets.Instantiate(BallPrefabPath).GetComponent<Ball>();
            return ball;
        }
    }
}
