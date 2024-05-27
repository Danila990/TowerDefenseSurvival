using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ObjectPull<T> where T : MonoBehaviour
    {
        protected readonly List<T> _pullList = new List<T>();
        protected readonly Transform _parent;

        public readonly T Prefab;

        public ObjectPull(T prefab)
        {
            Prefab = prefab;
            _parent = new GameObject("EnemyPull: " + prefab.name).transform;
        }

        public virtual T Get()
        {
            foreach (T objectPull in _pullList)
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
            T spawnObject = Object.Instantiate(Prefab);
            spawnObject.gameObject.SetActive(true);
            _pullList.Add(spawnObject);
            return spawnObject;
        }

        protected virtual void FirstCreate(T prefab)
        {
            T firstObject = Object.Instantiate(prefab);
            firstObject.gameObject.SetActive(false);
            _pullList.Add(firstObject);
        }
    }
}