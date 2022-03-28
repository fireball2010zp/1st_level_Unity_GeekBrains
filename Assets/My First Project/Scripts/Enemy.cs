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
        [SerializeField] private bool _isFire; // ����� �� ��������

        [SerializeField] private float _health = 50;
        
        private Vector3 _direction;
        public float speed = 2f;
        //private bool _isSprint;

        //private NavMeshAgent _agent;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
            // FindObjectOfType ���������� �� ���� ����� � ���������������� �� ���� �����������

            //_agent = GetComponent<NavMeshAgent>();
            // ������������� ������


        }
        private void Start()
        {
            //_agent.SetDestination(_player.transform.position);
            // ����� ����� SetDestination ��� ������� �������������� �������
            // � ������������ ����� � �������� 
        }

        private void Update()
        {
            Ray ray = new Ray(spawnPosition.position, transform.forward);
            // �������� ��� � ����� spawnPosition.position � ����������� ������� 
            // � ����� ��������� ���� �� �� ����������� ���� ��� �����
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
            // ray - ���
            // out RaycastHit hit - ������, ������� ��� ������� ��� ������������ 
            // 6 - ���������
            
                // if (Vector3.Distance(transform.position, _player.transform.position) < 6)


            //_direction.x = (Input.GetAxis("Horizontal"));
            //_direction.z = (Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.G))
                _direction.z = 1; // ��� Z �������� �� ����������� �����
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

        // ����� ���������� �������� ����������
        private void Fire()
        {
            _isFire = false;
            var shieldObj = Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform, 5, 10f);

            Invoke(nameof(Reloading), _cooldown);
            // nameof - ������ ����� � ������� ������� ������ Reloading, ��������� ��� � ������
        }

        private void Reloading()
        {
            _isFire = true;
        }

        // ����� ����������� �������� �������
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


