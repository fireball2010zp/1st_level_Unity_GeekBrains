using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Mine : MonoBehaviour
    {
        public GameObject enemy;

        private void OnTriggerEnter(Collider other)
        {
            enemy = GameObject.Find("Ghost");

            if (other.CompareTag("Ghost")) // проверяем, если зашел противник
            {
                Debug.Log(message: "Explosion!");
                Destroy(gameObject);
                Destroy(enemy);
            }
        }

    }
}

