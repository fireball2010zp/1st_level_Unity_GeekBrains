using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{ 
    // ���thatqc �������� �������� ��������� ��������
    public interface ITakeDamage
    {
        public void Hit(float damage);
        // ��� ������, ������� ��������� ��������� ITakeDamage ������ ����� � ���� ����� Hit
    }
}


