using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;
        private bool _isStopped;

        // метод срабатывает, когда в него заходит объект, в скобках прописывается ссылка
        // на объект, который зашел в этот триггер
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_isStopped) // проверяем, если зашел игрок, то поворачиваем дверь
            {
                _rotatePoint.Rotate(Vector3.up, 90);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !_isStopped)
            {
                _rotatePoint.Rotate(Vector3.up, -90);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    _isStopped = true;
            }
        }
    }
}


