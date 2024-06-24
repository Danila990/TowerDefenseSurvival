using UnityEngine;
using Zenject;

namespace TDS
{
    public class InjectPool<T> : Pool<T> where T : MonoBehaviour
    {
        protected readonly DiContainer _diContainer;

        public InjectPool(T prefab, DiContainer diContainer, int rangePoll = 3) : base(prefab, rangePoll)
        {
            _diContainer = diContainer;
        }

        public override T Create(bool isActive = true)
        {
            T spawnObject = _diContainer.InstantiatePrefabForComponent<T>(Prefab, _parent);
            spawnObject.gameObject.SetActive(isActive);
            _pool.Add(spawnObject);
            return spawnObject;
        }
    }
}