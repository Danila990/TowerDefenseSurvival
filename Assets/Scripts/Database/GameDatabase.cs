using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode.Database
{
    [CreateAssetMenu(fileName = "GameDatabase", menuName = "MyCode/Database/GameDatabase")]
    sealed class GameDatabase : ScriptableObject, IGameDatabase
    {
        [SerializeField] private ScriptableObject[] _datas;

        private Dictionary<Type, ScriptableObject> _containers;
        private bool _initialize = false;

        public T GetDataContainer<T>() where T : ScriptableObject
        {
            Initialize();
            var type = typeof(T);
            if(_containers.ContainsKey(type))
                throw new ArgumentNullException("type");

            return (T)_containers[type];
        }

        public void Initialize()
        {
            if(_initialize)
                return;

            _initialize = true;
            _containers = new Dictionary<Type, ScriptableObject>(_datas.Length);
            foreach (var data in _datas)
                _containers.Add(data.GetType(), Instantiate(data));
        }
    }
}