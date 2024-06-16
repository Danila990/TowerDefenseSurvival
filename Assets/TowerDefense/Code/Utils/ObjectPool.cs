using System.Collections.Generic;
using UnityEngine;

namespace Code.TowerDefense
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        protected readonly List<T> _poolList = new List<T>();
        protected readonly Transform _spawnParent;

        public readonly T Prefab;

        public ObjectPool(T prefab)
        {
            Prefab = prefab;
            _spawnParent = new GameObject("ObjectPool: " + prefab.name).transform;
        }

        public T Get()
        {
            foreach (T poolObject in _poolList)
            {
                if (poolObject.gameObject.activeInHierarchy == false)
                {
                    poolObject.gameObject.SetActive(true);
                    return poolObject;
                }
            }

            return Create();
        }

        public void CreateStartPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Create(false);
            }
        }

        public virtual T Create(bool isActive = true)
        {
            T newObject = Object.Instantiate(Prefab);
            newObject.gameObject.SetActive(isActive);
            _poolList.Add(newObject);
            return newObject;
        }
    }
}