using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform spawnPosition;

        private bool shooting = true;

        void Start()
        {
            _player = FindObjectOfType<Player>();

        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 5)
            {
                if (shooting)
                    StartCoroutine(TurrelFire());
            }
        }

        private IEnumerator TurrelFire()
        {
            shooting = false;
            Fire();
            yield return new WaitForSeconds(1);
            shooting = true;
        }

        void FixedUpdate()
        {
            // ���������� ���������� �� �������
            var direction = _player.transform.position - transform.position;
            // ��������� ��������� �������� (������ � �������) ����� ������ �� ������� �� ������

            direction.Set(direction.x, 0, direction.z);
            // ��������� �������� ������ �� ��� Y

            var stepRotate = Vector3.RotateTowards(transform.forward, 
                direction, _speedRotate * Time.fixedDeltaTime, 0f);
            // transform.forward - ������� ����������� ������� �������
            // direction - �������� ����� �������� ������� �������
            // _speedRotate * Time.fixedDeltaTime � �������� ��������
            // 0f � ������������ ����� �������

            transform.rotation = Quaternion.LookRotation(stepRotate);
            // ����� LookRotation - ����������� � ������� �����������

        }

        // ����� ���������� �������� ������
        private void Fire()
        {
            var shieldObj = Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(/*_player.transform,*/ 5, 10f);
        }
    }
}


