using UnityEngine;

namespace TD
{
    public class Timer
    {
        private readonly float duration;
        private float timeEnd;

        public bool IsTimerEnd => Time.time >= timeEnd;

        public Timer(float duration)
        {
            this.duration = duration;
            timeEnd = Time.time;
        }

        public void Start()
        {
            timeEnd = Time.time + duration;
        }
    }
}