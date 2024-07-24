using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MyCode.Database
{
    [CreateAssetMenu(fileName = "TowerContainer", menuName = "MyCode/Database/TowerContainer")]
    public class TowerContainer : ScriptableObject
    {
        [SerializeField] private TowerInfo[] _info;

        public TowerInfo GetInfo(int id)
        {
            foreach (var info in _info)
            {
                if(info.Id.Equals(id))
                    return info;
            }

            throw new ArgumentNullException(id.ToString());
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(_info == null || _info.Length == 0)
                return;

            for (int i = 0; i < _info.Length; i++)
            {
                _info[i].Id = i;
            }
        }
#endif
    }

    [Serializable]
    public class TowerInfo
    {
        public int Id;
        public AssetReferenceGameObject PrefabReference;
        public TowerStats Stats;
    }
}