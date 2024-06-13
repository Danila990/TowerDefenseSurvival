using System;
using UnityEngine;

namespace TD 
{
    [CreateAssetMenu(fileName = "GameDatabase", menuName = "Database/GameDatabase")]
    public class GameDatabase : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _datas;

        public T GetData<T>() where T : ScriptableObject
        {
            foreach (ScriptableObject data in _datas)
            {
                if (data.GetType().Equals(typeof(T)))
                {
                    return (T)data;
                }
            }

            throw new NullReferenceException($"Get data: {typeof(T)} is null");
        }

        public T GetNewData<T>() where T : ScriptableObject
        {
            return Instantiate(GetData<T>());
        }
    }
}