using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Mine : MonoBehaviour
    {
        //public GameObject enemy;
        
        [SerializeField] private float _damage = 10;

        private void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * 2, Color.blue);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TakeDamage takeDamage))
                takeDamage.HitMine(_damage);
            
            Ray ray = new Ray(transform.position, transform.forward);

            if (other.CompareTag("Ghost"))
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 10))
                {
                    Collider[] _col = Physics.OverlapSphere(hit.point, 10);
                    foreach (var col in _col)
                    {
                        if (col.GetComponent<Rigidbody>())
                        {
                            col.GetComponent<Rigidbody>().AddForce(-(hit.point - col.transform.position) * 300);

                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        
        //Debug.Log(message: "Explosion!");
        //Destroy(gameObject);
        //Destroy(enemy);
        /*
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out TakeDamage takeDamage))
                takeDamage.HitMine(_damage);
            // Destroy(gameObject);
            // TryGetComponent обходит все компоненты находящиеся на gameObject и если
            // какий либо компонент содержит интерфейс ITakeDamage, то вернуть (out) 
            // значение повреждения (takeDamage)
        }
        */
        
    }
}

