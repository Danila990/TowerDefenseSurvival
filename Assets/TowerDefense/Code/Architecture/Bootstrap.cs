using System.Collections.Generic;
using System.Linq;
using MyCode;
using UnityEngine;

namespace MyCode
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private EnemysController _enemyController;

        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            SetupSetting();
            RegisterServices();
        }

        private void Start()
        {
            _playerController.Init();
            _enemyController.Init();
        }

        private void Update()
        {
            _playerController.Update();
            _enemyController.Update();
        }

        private void SetupSetting()
        {
            Application.targetFrameRate = 60;
        }

        private void RegisterServices()
        {
            _serviceLocator = new ServiceLocator();

            _playerController.RegisterServices(_serviceLocator);
            _enemyController.RegisterServices(_serviceLocator);
        }
    }
}