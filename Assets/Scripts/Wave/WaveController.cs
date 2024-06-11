using UnityEngine;
using Zenject;

namespace TD
{
    public class WaveController : MonoBehaviour
    {
        private WaveSetting _waveSetting;
        private Vector3 _centerSpawn;

        [Inject]
        private void Construct(WaveSetting waveSetting, Tower tower)
        {
            _waveSetting = waveSetting;
            _centerSpawn = tower.transform.position;
        }

        private void OnSetRandomPosition(GameObject spawnObject)
        {
            Vector3 randomPostion = GetRandomPointAroundTower();
            spawnObject.transform.position = randomPostion;
        }

        private Vector3 GetRandomPointAroundTower()
        {
            Vector2Int spawnRange = _waveSetting.GetSpawnRange();
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(spawnRange.x, spawnRange.y);
            float x = _centerSpawn.x + distance * Mathf.Cos(angle);
            float z = _centerSpawn.z + distance * Mathf.Sin(angle);
            return new Vector3(x, _centerSpawn.y, z);
        }
    }
}