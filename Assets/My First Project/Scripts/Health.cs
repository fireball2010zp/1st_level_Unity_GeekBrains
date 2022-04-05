using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Health : MonoBehaviour
    {
        [Header("Health stats")]
        [SerializeField] private int _maxHealth = 100;

        public int _currentHealth;

        public event Action<float> HealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                ChangeHealth(-10);
        }   

        void ChangeHealth(int value)
        {
            _currentHealth += value;

            if (_currentHealth <= 0)
            {
                Death();
            }
            else
            {
                float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
                HealthChanged?.Invoke(_currentHealthAsPercantage);
            }
        }

        private void Death()
        {
            HealthChanged?.Invoke(0);
            Debug.Log("You are dead!");
        }

    }
}


