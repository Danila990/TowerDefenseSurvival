using System;
using UnityEngine;

namespace TD
{
    [CreateAssetMenu(fileName = "WavesSetting", menuName = "WavesSetting")]
    public class WavesSetting : ScriptableObject
    {
        [field: SerializeField] public EnemyFactoryData[] _waves { get; private set; }
        [field: SerializeField] public float _duration { get; private set; } = 300f;
        [field: SerializeField] public Vector2Int _rangeSpawn { get; private set; } = new Vector2Int(25, 35);

        private void OnValidate()
        {
            foreach (EnemyFactoryData waves in _waves)
            {
                if (waves.TimeToStart > _duration)
                {
                    waves.TimeToStart = _duration;
                }

                if (waves.TimeToStop > _duration)
                {
                    waves.TimeToStop = _duration;
                }
            }
        }
    }
}