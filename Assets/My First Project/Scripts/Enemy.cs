using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFirstProject
{
    public class Enemy : MonoBehaviour, TakeDamage
    
    {
        [SerializeField] private Player _player;
        public Transform spawnPosition;

        [SerializeField] private GameObject _bulletPrefab;

        [SerializeField] private float _cooldown;
        [SerializeField] private bool _isFire; // можем ли стрелять

        [SerializeField] private float _health = 50;
        
        private Vector3 _direction;
        public float speed = 2f;
        //private bool _isSprint;

        //private NavMeshAgent _agent;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            // FindObjectOfType проходится по всей сцене и инициализируется на всех противниках

            //_agent = GetComponent<NavMeshAgent>();
            // инициализация агента


        }
        private void Start()
        {
            //_agent.SetDestination(_player.transform.position);
            // через метод SetDestination при запуске просчитывается маршрут
            // и отправляется агент в движение 
        }

        private void Update()
        {
            Ray ray = new Ray(spawnPosition.position, transform.forward);
            // создаётся луч с точки spawnPosition.position в направлении взгляда 
            // и далее проверяем есть ли по направлению луча наш игрок
            //Debug.DrawRay(spawnPosition.position, transform.forward * 10, Color.blue);
            if (Physics.Raycast(ray, out RaycastHit hit, 6))
            {
                Debug.DrawRay(spawnPosition.position, transform.forward * hit.distance, Color.blue);
                Debug.DrawRay(hit.point, hit.normal, Color.magenta);
                
                if (hit.collider.CompareTag("Player"))
                {
                    if (_isFire)
                        Fire();
                }
            }
            // ray - луч
            // out RaycastHit hit - данные, которые луч получит при столкновении 
            // 6 - дистанция
            
                // if (Vector3.Distance(transform.position, _player.transform.position) < 6)


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
            _isFire = false;
            var shieldObj = Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform, 5, 10f);

            Invoke(nameof(Reloading), _cooldown);
            // nameof - взятие имени у каждого объекта метода Reloading, переводит его в строку
        }

        private void Reloading()
        {
            _isFire = true;
        }

        // метод реализующий движение объекта
        private void Move(float delta)
        {
            transform.position += _direction * speed * delta;
        }
        
        public void HitMine(float damage)
        {
            _health -= damage;

            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}


