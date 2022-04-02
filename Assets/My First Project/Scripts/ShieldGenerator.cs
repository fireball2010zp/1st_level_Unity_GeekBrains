using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public sealed class ShieldGenerator : WeaponFabric // sealed - ��������� ������������
    {
        private int _level;
        public ShieldGenerator(int level, GameObject spawnPrefab, Transform spawnPoint) : base(spawnPrefab, spawnPoint)
        {
            _level = level;
        }
        public override GameObject Spawn()
        {
            var shieldObj = Object.Instantiate(_spawnPrefab, _spawnPoint.position, _spawnPoint.rotation);
            // Instantiate - ���������� ������ �� ������
            // (Unity ����� ���� ���������� ����������� New ������ ������)
            // ��� ��������� � ����������� ��������� � Prefab'� _spawnPrefab
            // _spawnPoint.position - ����������
            // _spawnPoint.rotation - ������� ���� ������ � ��������

            var shield = shieldObj.GetComponent<Shield>();
            // � ������ GetComponent � ������� ��������� ������ �� ��������� ������ ������� ����
            // � � ���������� shield ����������� ��� ���������� ������ Shield
            // ��� ������ <Shield> ����� ������� <Transform>

            shield.Init(10 * _level);
            // ��������� ���� ����� ������������� � ������ ������ ���������

            shield.transform.SetParent(_spawnPoint);
            // �������� ���� � �������� spawnPosition

            return shieldObj;
        }
    }
}

