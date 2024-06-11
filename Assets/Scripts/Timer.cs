using UnityEngine;

namespace TD
{
    public class Timer
    {
        private readonly float _duration;
        private float _timeEnd;

        public bool IsTimerEnd => Time.time >= _timeEnd;

        public Timer(float duration)
        {
            _duration = duration;
            _timeEnd = Time.time;
        }

        public void Start()
        {
            _timeEnd = Time.time + _duration;
        }
    }
}