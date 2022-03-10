using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 3;
        private Transform _target;
        private float _speed;

        public void Init(Transform target, float lifeTime, float speed)
        {
            _target = target;
            _speed = speed;
            Destroy(gameObject, lifeTime);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            // метод MoveTowards просчитывает шаг нашего персонажа
            // (текущая позиция, позиция нашей цели, скорость движения снаряда)

            // снаряд получился самонаводящийся, ниже код для прямолинейного движения снаряда
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
                takeDamage.Hit(_damage);
            // TryGetComponent обходит все компоненты находящиеся на gameObject и если
            // какий либо компонент содержит интерфейс ITakeDamage, то вернуть (out) 
            // значение повреждения (takeDamage)
        }
    }
}




