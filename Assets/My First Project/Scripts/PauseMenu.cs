using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstProject
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject _pauseMenu;

        [SerializeField] KeyCode keyPauseMenu;

        bool _isPauseManu = false;

        private void Start()
        {
            _pauseMenu.SetActive(false);
        }

        private void Update()
        {
            ActivePauseMenu();
        }

        void ActivePauseMenu()
        {
            if (Input.GetKeyDown(keyPauseMenu))
            {
                _isPauseManu = !_isPauseManu;
            }

            if (_isPauseManu)
            {
                _pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                _pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }

        public void Continue()
        {
            _isPauseManu = false;
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


