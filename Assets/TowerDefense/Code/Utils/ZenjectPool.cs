using UnityEngine;
using Zenject;

namespace Code.TowerDefense
{
    public class ZenjectPool<T> : ObjectPool<T> where T : MonoBehaviour
    {
        protected readonly DiContainer _diContainer;

        public ZenjectPool(T prefab, DiContainer diContainer) : base(prefab)
        {
            _diContainer = diContainer;
        }

        public override T Create(bool isActive = true)
        {
            T spawnObject = _diContainer.InstantiatePrefabForComponent<T>(Prefab, Vector3.zero, Quaternion.identity, _spawnParent);
            spawnObject.gameObject.SetActive(isActive);
            _poolList.Add(spawnObject);
            return spawnObject;
        }
    }
}