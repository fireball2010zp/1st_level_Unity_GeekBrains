using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;

        void Start()
        {
            _player = FindObjectOfType<Player>();
            // FindObjectOfType проходится по всей сцене и инициализируется на всех противниках

        }

    }
}


