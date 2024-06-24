using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Pool<T> where T : MonoBehaviour
    {
        protected readonly List<T> _pool = new List<T>();
        protected readonly Transform _parent;

        public readonly T Prefab;

        public Pool(T prefab, int rangePoll = 3)
        {
            Prefab = prefab;
            _parent = new GameObject("Pool: " + prefab.name).transform;
            _pool = new List<T>(rangePoll * 2);
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