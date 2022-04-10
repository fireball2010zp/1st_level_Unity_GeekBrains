using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstProject
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarFilling;

        [SerializeField] Health _health;

        [SerializeField] private Gradient _gradient;

        private Camera _camera;

        private void Awake()
        {
            _health.HealthChanged += OnHealthChanged;
            _camera = Camera.main;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float valueAsPercantage)
        {
            Debug.Log(valueAsPercantage);
            _healthBarFilling.fillAmount = valueAsPercantage;
            _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
        }

        void LateUpdate()
        {
            transform.LookAt(new Vector3(_camera.transform.position.x, transform.position.y, _camera.transform.position.z));
            transform.Rotate(0, 180, 0);
        }

    }
}


