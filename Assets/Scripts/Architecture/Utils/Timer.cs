using UnityEngine;

namespace Code
{
    public class Timer
    {
        private float _timeEnd;
        private float _timeDuration;

        public bool IsTimerEnd => Time.time >= _timeEnd;

        public Timer(float duration)
        {
            _timeDuration = duration;
            _timeEnd = Time.time;
        }

        public void Start() => _timeEnd = Time.time + _timeDuration;
    }
}