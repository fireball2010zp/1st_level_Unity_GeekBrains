using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{ 
    // ��������� �������� �������� ��������� ��������
    public interface ITakeDamage
    {
        public void Hit(float damage);
        // ��� ������, ������� ��������� ��������� ITakeDamage ������ ����� � ���� ����� Hit
    }
}


