using UnityEngine;

namespace MyCode.Database
{
    public interface IGameDatabase
    {
        public T GetDataContainer<T>() where T : ScriptableObject;
    }
}