using System;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "WaveContainer", menuName = "TowerDefense/Wave/WaveContainer")]
    public class WaveContainer : ScriptableObject
    {
        [SerializeField] private WaveData[] _waveDatas;

        public WaveData[] GetWaveDatas()
        {
            return _waveDatas;
        }
    }
}