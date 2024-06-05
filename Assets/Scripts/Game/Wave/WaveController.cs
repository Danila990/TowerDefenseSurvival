using UnityEngine;
using Zenject;

namespace TD
{
    public class WaveController : MonoBehaviour
    {
        private WaveSetting waveSetting;
        private Vector3 centerSpawn;

        [Inject]
        private void Construct(WaveSetting waveSetting, Tower tower)
        {
            this.waveSetting = waveSetting;
            this.centerSpawn = tower.transform.position;
        }

        private void OnSetRandomPosition(GameObject spawnObject)
        {
            Vector3 randomPostion = GetRandomPointAroundTower();
            spawnObject.transform.position = randomPostion;
        }

        private Vector3 GetRandomPointAroundTower()
        {
            Vector2Int spawnRange = waveSetting.GetSpawnRange();
            float angle = Random.Range(0f, Mathf.PI * 2);
            float distance = Random.Range(spawnRange.x, spawnRange.y);
            float x = centerSpawn.x + distance * Mathf.Cos(angle);
            float z = centerSpawn.z + distance * Mathf.Sin(angle);
            return new Vector3(x, centerSpawn.y, z);
        }
    }
}