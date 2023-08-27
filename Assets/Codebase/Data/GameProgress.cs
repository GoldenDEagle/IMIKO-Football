using System;
using System.Collections.Generic;

namespace Assets.Codebase.Data
{
    [Serializable]
    public class GameProgress
    {
        public List<PlayerResult> AllResults;

        public GameProgress() 
        { 
            AllResults = new List<PlayerResult>();
        }
    }
}
