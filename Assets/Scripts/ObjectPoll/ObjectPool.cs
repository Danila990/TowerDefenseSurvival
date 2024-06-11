using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        protected readonly List<T> _objectsPull = new List<T>();
        protected readonly Transform _spawnParent;

        public readonly T ObjectPrefab;

        public ObjectPool(T prefab)
        {
            ObjectPrefab = prefab;
            _spawnParent = new GameObject("ZenjectPool: " + prefab.name).transform;
        }

        public T Get()
        {
            foreach (T objectPull in _objectsPull)
            {
                if (objectPull.gameObject.activeInHierarchy == false)
                {
                    objectPull.gameObject.SetActive(true);
                    return objectPull;
                }
            }

            return Create();
        }

        public virtual T Create()
        {
            T spawnObject = Object.Instantiate(ObjectPrefab);
            spawnObject.gameObject.SetActive(true);
            _objectsPull.Add(spawnObject);
            return spawnObject;
        }
    }
}