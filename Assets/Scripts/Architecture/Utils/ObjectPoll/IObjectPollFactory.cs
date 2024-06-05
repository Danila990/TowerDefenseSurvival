using UnityEngine;

namespace TD
{
    public interface IObjectPollFactory
    {
        public ObjectPool<T> CreateDefaultPoll<T>(T prefab) where T : MonoBehaviour;
        public ZenjectPool<T> CreateZenjectPoll<T>(T prefab) where T : MonoBehaviour;
    }
}