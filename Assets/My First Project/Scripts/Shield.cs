using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    // ������ ���� � ����� Prefab'e

    // ������� ���������� ����������� � ������������� ������ MonoBehaviour
    // ����� ���������� ����������� � ������ Shield

    public class Shield : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _durability; // ��������� ����
                                                    // �������� [SerializeField] ������������ ��� ��������� � ���������� Unity
                                                    // �������� Durability

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 10f); // ��� ����� ���� 3 ������� ����� ���������
        }

        public void Hit(float damage)
        {
            _durability -= damage;

            if (_durability <= 0)
                Destroy(gameObject);
        }
    }
}

