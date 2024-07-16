using UnityEngine;

namespace MyCode
{
    public class Bullet : MonoBehaviour 
    {
        private Enemy _target;
        private float _damage;
        private float _speed;
        private Vector3 _lastPoint = Vector3.zero;

        public void Init(float damage, float speed, Enemy enemy)
        {
            _target = enemy;
            _damage = damage;
            _speed = speed;
            _lastPoint = Vector3.zero;
        }

        private void Update()
        {
            if(!_target.gameObject.activeInHierarchy)
            {
                _lastPoint = _target.transform.position;
            }
            
            if(_lastPoint != Vector3.zero)
            {
                if (Vector3.Distance(transform.position, _lastPoint) <= 1f)
                {
                    gameObject.SetActive(false);
                    return;
                }

                Move(_lastPoint);
            }
            else
            {
                if (Vector3.Distance(transform.position, _target.transform.position) <= 1f)
                {
                    _target.TakeDamage(_damage);
                    gameObject.SetActive(false);
                    return;
                }

                Move(_target.transform.position);
            }
        }

        private void Move(Vector3 movePoint)
        {
            Vector3 targetPosition = new Vector3(movePoint.x, transform.position.y, movePoint.z);
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}