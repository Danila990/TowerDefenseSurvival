using UnityEngine;

public class Timer
{
    private readonly float _duration;
    private float _timeEnd;

    public bool IsTimerEnd => Time.time >= _timeEnd;

    public Timer(float duration, bool startDelay = false)
    {
        _duration = duration;
        if (startDelay)
        {
            Start();
        }
        else
        {
            _timeEnd = Time.time;
        }

    }

    public void Start()
    {
        _timeEnd = Time.time + _duration;
    }
}