using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private AudioReverbZone _component;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _component.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _component.enabled = false;
    }
}
