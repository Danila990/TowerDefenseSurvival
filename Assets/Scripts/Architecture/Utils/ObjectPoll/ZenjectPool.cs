using UnityEngine;
using Zenject;

namespace TD
{
    public class ZenjectPool<T> : ObjectPool<T> where T : MonoBehaviour
    {
        protected readonly DiContainer diContainer;

        public ZenjectPool(T prefab, DiContainer diContainer) : base(prefab)
        {
            this.diContainer = diContainer;
        }

        public override T Create()
        {
            T spawnObject = diContainer.InstantiatePrefabForComponent<T>(ObjectPrefab, Vector3.zero, Quaternion.identity, spawnParent);
            spawnObject.gameObject.SetActive(true);
            objectsPull.Add(spawnObject);
            return spawnObject;
        }
    }
}