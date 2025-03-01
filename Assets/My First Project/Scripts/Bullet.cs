using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _sparksPrefab;

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
            
            // ������������ �������� ���� (�� ����� FixedUpdate, � ����� ������ ����)
            _rigidbody.AddForce(transform.forward * _force);
            // AddForce - ���������� ����
            // AddTorque - ���������� ��������
        }

        /*
        // Update is called once per frame
        void FixedUpdate()
        {
            // transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            // ����� MoveTowards ������������ ��� ������ ���������
            // (������� �������, ������� ����� ����, �������� �������� �������)

            // ������ ��������� ���������������, ���� ��� ��� �������������� �������� �������
            //transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }*/

        private void OnCollisionEnter(Collision collision)
        {
            var particle = Instantiate(_sparksPrefab);
            particle.transform.position = collision.contacts[0].point;
            particle.transform.rotation = Quaternion.Euler(collision.contacts[0].normal);
            var lifetime = particle.main.duration + particle.main.startLifetimeMultiplier;
            Destroy(particle.gameObject, lifetime);
            Destroy(gameObject);

            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
                takeDamage.Hit(_damage);
                //Destroy(gameObject);
            // TryGetComponent ������� ��� ���������� ����������� �� gameObject � ����
            // ����� ���� ��������� �������� ��������� ITakeDamage, �� ������� (out) 
            // �������� ����������� (takeDamage)
        }
    }
}




