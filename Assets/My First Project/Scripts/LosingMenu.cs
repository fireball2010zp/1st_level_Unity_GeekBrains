using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstProject
{
    public class LosingMenu : MonoBehaviour
    {
        public GameObject _losingMenu;

        Health _currentHealth;

        bool _isLosingMenu = false;

        private void Start()
        {
            _losingMenu.SetActive(false);
        }
        
        private void Update()
        {
            ActiveLosingMenu();
        }

        void ActiveLosingMenu()
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
                _isLosingMenu = !_isLosingMenu;

            if (_isLosingMenu)
            {
                _losingMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                _losingMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }

        public void Restart()
        {
            Debug.Log("Restart!");
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            Debug.Log("Main Menu!");
            SceneManager.LoadScene(0);
        }
    }
}


