using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFirstProject
{
    public class VolumeControl : MonoBehaviour
    {
        public string volumeParameter = "MasterVolume";
        public AudioMixer mixer;
        public Slider slider;

        private const float _multiplier = 10f;
        private float _volumeValue;

        public void Awake()
        {
            slider.onValueChanged.AddListener(HandleSliderValueChanged);
        }

        private void HandleSliderValueChanged(float value)
        {
            _volumeValue = Mathf.Log10(value) * _multiplier;
            mixer.SetFloat(volumeParameter, _volumeValue);

        }

        void Start()
        {
            //_volumeValue = PlayerPrefs.SetFloat(volumeParameter, Mathf.Log10(slider.maxValue) * _multiplier);
            //slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
        }
    }
}


