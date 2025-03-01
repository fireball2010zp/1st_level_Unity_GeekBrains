using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyFirstProject
{
    public class Player : MonoBehaviour // ������ ����� �� ��� ������
                                                 // � MonoBehaviour ����������� ������
    {
        public KeyCode keySpell1;
        public KeyCode keySpell2;

        public GameObject shieldPrefab;   // ������ - ���
        public GameObject bulletPrefab;   
        public Transform spawnPosition;   // ������� ���� � ������������ � ��� �������
        public Transform spawnBulletPosition;

        public GameObject minePrefab;   // ������ - ����
        public Transform spawnPositionMine;   // ������� ���� � ������������

        private bool _isSpawnShield;
        private bool _isFire;
        private bool _isSpawnMine;

        [SerializeField] private float _cooldownTime1;
        [SerializeField] private float _cooldownTime2;
        [SerializeField] private bool _cooldown1;
        [SerializeField] private bool _cooldown2;

        [SerializeField] private Rigidbody _rb;

        [SerializeField] private float _ammunition = 0;

        [HideInInspector] private int level = 1;
        // [HideInInspector] - ������� ��� ������� � ���������� ���� Unity

        // ��������� ��� ����������� (Vector2 - ������ � ����� �����������)
        private Vector3 _direction;
        public float speed = 2f;
        // Vector2 - ��� X (������) � ��� Y (�����), Vector3 - ��� Z (�����)

        public float speedRotate = 20f;

        private bool _isSprint;

        [SerializeField] private float _jumpForce = 10f;

        [SerializeField] private Animator _anim;

        private ShieldGenerator _shieldGenerator;
        private Gun _gun;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _anim = GetComponent<Animator>();
            _gun = new Gun(bulletPrefab, spawnPosition);
            _shieldGenerator = new ShieldGenerator(10, shieldPrefab, spawnPosition);
        }
        
        void Start()
        {
            /*
            var point1 = new Vector3(1f, 5f, 1462f); 
            // ������ ���������� �������, ����� ���� ��� �����, � ����� ��� � ����������
            // �� ������ ��������� �� �������� �����
            var point2 = new Vector3(16f, 5f, 142f);

            // ������ �������� ���������� ����� �������
            var dist = Vector3.Distance(point1, point2);
            Debug.Log(dist);

            // ����� ������ Vector3.down
            Debug.Log(Vector3.down.magnitude);

            // ����� ������ Vector3.one (��� �������� = 1)
            Debug.Log(Vector3.one.magnitude);
            */
        }

        void Update()
        {
            if (Input.GetKeyDown(keySpell1) && _cooldown1)
                _isSpawnShield = true;
            if (Input.GetKeyDown(keySpell2) && _cooldown2)
                _isFire = true;

            /*
            // ��������� ������� ����� ������ ����
                if (Input.GetMouseButtonDown(1)) // Down - ��� �������, Up - ��� �������
                    _isSpawnShield = true;
            // ���� ����� �������� � ��� ����� �� ��� ����������
            */

            if (Input.GetKey(KeyCode.M))
                    _isSpawnMine = true;
            /*
            _direction.x = (Input.GetAxis("Horizontal"));
            _direction.z = (Input.GetAxis("Vertical"));

             - ���������� ������ ��������� ���� �������:
            // ��������� ������� ������ �� ���������� (����������� ��������)
            if (Input.GetKey(KeyCode.W))
                _direction.z = 1; // ��� Z �������� �� ����������� �����
            else if (Input.GetKey(KeyCode.S))
                _direction.z = -1;
            else 
                _direction.z = 0;
            */

            _direction.x = (Input.GetAxis("Horizontal"));
            _direction.z = (Input.GetAxis("Vertical"));

            _isSprint = (Input.GetButton("Sprint"));

            _anim.SetBool("IsWalking", _direction != Vector3.zero);

            if (Input.GetKeyDown(KeyCode.Space))
                    GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                _cooldown1 = false;
                StartCoroutine(Cooldown1(_cooldownTime1, 1));
                _shieldGenerator.Spawn();
            }

            if (_isFire)
            {
                _isFire = false;
                _cooldown2 = false;
                StartCoroutine(Cooldown1(_cooldownTime2, 2));
                _gun.Spawn();
            }

            if (_isSpawnMine)
            {
                _isSpawnMine = false;
                SpawnMine();
            }
            
            Move(Time.fixedDeltaTime);
            // ����������� �������� fixedDeltaTime = 0,2�
        }

        private IEnumerator Cooldown1(float time, int numSpell)
        {
            yield return new WaitForSeconds(time);
            switch (numSpell)
            {
                case 1:
                    _cooldown1 = true;
                    break;
                case 2:
                    _cooldown2 = true;
                    break;
            }
        }

        /*
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
            
        }*/

        private void SpawnMine()
        {
            var mineObj = Instantiate(minePrefab, spawnPositionMine.position, spawnPositionMine.rotation);
            var mine = mineObj.GetComponent<Mine>();
        }

        
        // ����� ����������� �������� �������
        private void Move(float delta)
        {
            float sprint = (_isSprint) ? 2f : 1f;
            
            _direction = transform.TransformDirection(_direction);
            _rb.MovePosition(transform.position + _direction.normalized * speed * sprint * Time.fixedDeltaTime);

            // var fixedDirection = transform.TransformDirection(_direction.normalized);
            // transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;
            // � ������� ������� ���������� �������
            // .normalized (���� ����� Normalize) - ���������� �������� magnitude (������� Vector3)
            // � 1 ��� ������� ���� ������ ����������� (�� ��������� magnitude z+x = 1.73,
            // ������� �� ��������� �������� ������� ����������)

            // ������� ����� �����
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));

            //Vector3 rotate = new Vector3(0f, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0f);
        }

        private void OnTriggerStay(Collider other)
        { 

            if (other.gameObject.tag == "Ammo")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _ammunition += 10;
                    Debug.Log(message: "You got 10 bullets!");
                }
            }

            if (other.gameObject.tag == "Exit")
            {
                Debug.Log(message: "You completed the level!");
            }
        }
    }
}


/*

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

