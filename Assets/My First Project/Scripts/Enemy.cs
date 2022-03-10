using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;
        public Transform spawnPosition;

        [SerializeField] private GameObject _bulletPrefab;

        private Vector3 _direction;
        public float speed = 2f;
        //private bool _isSprint;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            // FindObjectOfType проходится по всей сцене и инициализируется на всех противниках

        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 20)
            {
                if (Input.GetMouseButtonDown(0))
                    Fire();
            }

            //_direction.x = (Input.GetAxis("Horizontal"));
            //_direction.z = (Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.G))
                _direction.z = 1; // ось Z отвечает за направление вперёд
            else if (Input.GetKey(KeyCode.T))
                _direction.z = -1;
            else
                _direction.z = 0;

            //_isSprint = (Input.GetButton("Sprint"));
        }

        void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        // метод реализации стрельбы противника
        private void Fire()
        {
            var shieldObj = Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform, 5, 10f);
        }


        // метод реализующий движение объекта
        private void Move(float delta)
        {
            transform.position += _direction * speed * delta;
        }
    }
}


