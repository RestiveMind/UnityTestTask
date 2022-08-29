using UnityEngine;

namespace Utils
{
    public static class TimerHelper
    {
        public static bool PassedSince(float interval, float startTime)
        {
            return Time.time - startTime > interval;
        }
    }
}
