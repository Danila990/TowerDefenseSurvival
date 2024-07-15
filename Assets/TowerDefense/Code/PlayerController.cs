using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCode;
using UnityEngine;

namespace MyCode
{
    [Serializable]
    public class PlayerController
    {
        [SerializeField] private PlayerBody _playerBody;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerAbility _playerAbility;

        public void Init()
        {
            _playerBody.Init(_player);
        }

        public void Update()
        {

        }

        public void RegisterServices(ServiceLocator serviceLocator)
        {
            serviceLocator.Register(_player);
            serviceLocator.Register(_playerBody);
        }
    }
}
