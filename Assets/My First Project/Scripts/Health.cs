using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstProject
{
    public class Health : MonoBehaviour, ITakeDamage
    {
        [Header("Health stats")]
        [SerializeField] private int _maxHealth = 100;

        public float _currentHealth;

        public event Action<float> HealthChanged;

        public GameObject _losingMenu;
        bool _isLosingMenu = false;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
           /* if (Input.GetKeyDown(KeyCode.F))
                ChangeHealth(-10);*/
        }   

        void ChangeHealth(float value)
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
            SceneManager.LoadScene(0);
        }

        public void Hit(float damage)
        {
            _currentHealth -= damage;
            ChangeHealth(-damage);
            /*
            if (_currentHealth <= 0)
            {

                //Time.timeScale = 0f;
                //Cursor.lockState = CursorLockMode.None;

                // SceneManager.LoadScene(0);
                // Destroy(gameObject);
            }*/
            
        }

    }

}


