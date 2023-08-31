using UnityEngine;

namespace Assets.Codebase.Utils
{
    public class TimeConverter
    {
        // returns time in 0:00
        public static string TimeInMinutes(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            return formattedTime;
        }
    }
}
