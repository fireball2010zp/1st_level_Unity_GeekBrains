using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _force = 300;
        private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
            

        public void Init(float lifeTime, float speed)
        {
            _speed = speed;
            Destroy(gameObject, lifeTime);
            
            // альтернатива движения пули (не через FixedUpdate, а через твёрдое тело)
            _rigidbody.AddForce(transform.forward * _force);
            // AddForce - добавление силы
            // AddTorque - добавление вращения
        }

        /*
        // Update is called once per frame
        void FixedUpdate()
        {
            // transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            // метод MoveTowards просчитывает шаг нашего персонажа
            // (текущая позиция, позиция нашей цели, скорость движения снаряда)

            // снаряд получился самонаводящийся, ниже код для прямолинейного движения снаряда
            //transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }*/

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
                takeDamage.Hit(_damage);
                //Destroy(gameObject);
            // TryGetComponent обходит все компоненты находящиеся на gameObject и если
            // какий либо компонент содержит интерфейс ITakeDamage, то вернуть (out) 
            // значение повреждения (takeDamage)
        }
    }
}




