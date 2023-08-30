using System;

namespace Assets.Codebase.Data
{
    [Serializable]
    public class PlayerResult
    {
        public string PlayerName;
        public int Score;

        public PlayerResult(string name, int score)
        {
            PlayerName = name;
            Score = score;
        }
    }
}
