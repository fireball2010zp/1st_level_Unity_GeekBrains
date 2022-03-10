using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Ammunition : MonoBehaviour
    {
        //[SerializeField] private float _bullets = 10;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    Debug.Log(message: "You took ammo!");
                    Destroy(gameObject);
                }
            }
        }
    }
}

