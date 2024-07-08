using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Pool<T> where T : MonoBehaviour
    {
        protected readonly List<T> _pool = new List<T>(10);
        protected readonly Transform _parent;

        public readonly T Prefab;

        public Pool(T prefab)
        {
            Prefab = prefab;
            _parent = new GameObject("Pool: " + prefab.name).transform;
        }

        public T[] GetAll()
        {
            return _pool.ToArray(); 
        }

        public T Get()
        {
            foreach (T poolObject in _pool)
            {
                if (poolObject.gameObject.activeInHierarchy == false)
                {
                    poolObject.gameObject.SetActive(true);
                    return poolObject;
                }
            }

            return Create();
        }

        public virtual T Create(bool isActive = true)
        {
            T newObject = Object.Instantiate(Prefab, _parent);
            newObject.gameObject.SetActive(isActive);
            _pool.Add(newObject);
            return newObject;
        }
    }
}