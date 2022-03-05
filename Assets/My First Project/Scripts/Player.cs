using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyFirstProject
{
    public class Player : MonoBehaviour // ������ ����� �� ��� ������
                                        // � MonoBehaviour ����������� ������
    {
        public GameObject shieldPrefab;   // ������ - ���
        public Transform spawnPosition;   // ������� ���� � ������������ � ��� �������



        private bool _isSpawnShield;
        [HideInInspector] private int level = 1;
        // [HideInInspector] - ������� ��� ������� � ���������� ���� Unity

        // ��������� ��� ����������� (Vector2 - ������ � ����� �����������)
        private Vector3 _direction;
        public float speed = 2f;
        // Vector1 - ��� X (������), Vector2 - ��� Y (�����), Vector3 - ��� Z (�����)

        private bool _isSprint;

        void Awake()
        {
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            // ��������� ������� ����� ������ ����
            if (Input.GetMouseButtonDown(1)) // Down - ��� �������, Up - ��� �������
                _isSpawnShield = true;
            // ���� ����� �������� � ��� ����� �� ��� ����������

            _direction.x = (Input.GetAxis("Horizontal"));
            _direction.z = (Input.GetAxis("Vertical"));

            /*
            // ��������� ������� ������ �� ���������� (����������� ��������)
            if (Input.GetKey(KeyCode.W))
                _direction.z = 1; // ��� Z �������� �� ����������� �����
            else if (Input.GetKey(KeyCode.S))
                _direction.z = -1;
            else 
                _direction.z = 0;
            */

            _isSprint = (Input.GetButton("Sprint"));


        }

        void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }

            Move(Time.fixedDeltaTime);
            // ����������� �������� fixedDeltaTime = 0,2�
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            // Instantiate - ���������� ������ �� ������
            // (Unity ����� ���� ���������� ����������� New ������ ������)
            // ��� ��������� � ����������� ��������� � Prefab'� shieldPrefab
            // spawnPosition.position - ����������
            // spawnPosition.rotation - ������� ���� ������ � ��������

            var shield = shieldObj.GetComponent<Shield>();
            // � ������ GetComponent � ������� ��������� ������ �� ��������� ������ ������� ����
            // � � ���������� shield ����������� ��� ���������� ������ Shield
            // ��� ������ <Shield> ����� ������� <Transform>

            shield.Init(10 * level);
            // ��������� ���� ����� ������������� � ������ ������ ���������

            shield.transform.SetParent(spawnPosition);
            // �������� ���� � �������� spawnPosition
        }

        // ����� ����������� �������� �������
        private void Move(float delta)
        {
            transform.position += _direction * (_isSprint ? speed * 2 : speed) * delta;
            // � ������� ������� ���������� �������
        }
    }
}


/*
�������
- ������ �� ������������ ������ ������� Event functions (Unity functions)?
- MonoBehaviour �� ������������ ��� ����������� ����� (��������)



������� Awake() � Start() ��������� � ����� ������������� ���������� ����� �������
FixedUpdate() - ���� ������ (������� �� ������������������ �������� �������), ����������� ������ ������������� ������� ������� (��������� � Edit � Project Settings � Time � Fixed Timestep)
Update() � LateUpdate() - ���� ������� ������ (������� ������� �� fps)

������� �������:

1. Awake()
2. OnEnable()
3. Start()

4. Update()
5. LateUpdate()

*/

