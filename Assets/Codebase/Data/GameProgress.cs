using System;
using System.Collections.Generic;

namespace Assets.Codebase.Data
{
    [Serializable]
    public class GameProgress
    {
        public int CurrentScore;
        public MapId CurrentMap;
        public List<PlayerResult> AllResults;

        public GameProgress() 
        { 
            CurrentScore = 0;
            CurrentMap = MapId.None;

            AllResults = new List<PlayerResult>();
        }
    }
}
