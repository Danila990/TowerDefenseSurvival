using UnityEngine;

namespace MyCode
{
    [CreateAssetMenu(fileName = "WaveContainer", menuName = "MyCode/Wave/WaveContainer")]
    public class WaveContainer : ScriptableObject
    {
        [SerializeField] private WaveData[] _waveDatas;

        public WaveData[] GetWaveDatas()
        {
            return _waveDatas;
        }
    }
}