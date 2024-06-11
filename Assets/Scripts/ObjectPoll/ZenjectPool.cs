using UnityEngine;
using Zenject;

namespace TD
{
    public class ZenjectPool<T> : ObjectPool<T> where T : MonoBehaviour
    {
        protected readonly DiContainer _diContainer;

        public ZenjectPool(T prefab, DiContainer diContainer) : base(prefab)
        {
            _diContainer = diContainer;
        }

        public override T Create()
        {
            T spawnObject = _diContainer.InstantiatePrefabForComponent<T>(ObjectPrefab, Vector3.zero, Quaternion.identity, _spawnParent);
            spawnObject.gameObject.SetActive(true);
            _objectsPull.Add(spawnObject);
            return spawnObject;
        }
    }
}