using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    // ������ ���� � ����� Prefab'e

    // ������� ���������� ����������� � ������������� ������ MonoBehaviour
    // ����� ���������� ����������� � ������ Shield

    public class Shield : MonoBehaviour
    {
        [SerializeField] private float _durability; // ��������� ����
                                                    // �������� [SerializeField] ������������ ��� ��������� � ���������� Unity
                                                    // �������� Durability

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 3f); // ��� ����� ���� 3 ������� ����� ���������
        }

    }
}

