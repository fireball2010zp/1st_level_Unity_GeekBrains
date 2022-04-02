using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePoint;

        [SerializeField] private Animator _anim;

        private bool _isStopped;
        private readonly int IsOpen = Animator.StringToHash("IsOpen");

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        // метод срабатывает, когда в него заходит объект, в скобках прописывается ссылка
        // на объект, который зашел в этот триггер
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_isStopped) // проверяем, если зашел игрок, то поворачиваем дверь
            {
                _anim.SetBool(IsOpen, true);
                //_rotatePoint.Rotate(Vector3.up, 90);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !_isStopped)
            {
                _anim.SetBool(IsOpen, false);
                //_rotatePoint.Rotate(Vector3.up, -90);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    _anim.enabled = false;
                    //_isStopped = true;
            }
        }
    }
}


