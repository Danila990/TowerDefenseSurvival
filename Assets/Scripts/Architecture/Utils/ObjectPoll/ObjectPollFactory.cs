using UnityEngine;
using Zenject;

namespace TD
{
    public class ObjectPollFactory : IObjectPollFactory
    {
        private readonly DiContainer diContainer;

        public ObjectPollFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public ObjectPool<T> CreateDefaultPoll<T>(T prefab) where T : MonoBehaviour
        {
            ObjectPool<T> poll = new ObjectPool<T>(prefab);
            return poll;
        }

        public ZenjectPool<T> CreateZenjectPoll<T>(T prefab) where T : MonoBehaviour
        {
            ZenjectPool<T> poll = new ZenjectPool<T>(prefab, diContainer);
            return poll;
        }
    }
}