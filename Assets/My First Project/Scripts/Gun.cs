using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Gun : WeaponFabric
    {

        public Gun(GameObject spawnPrefab, Transform spawnBulletPosition) : base(spawnPrefab, spawnBulletPosition)
        {
        }
        public override GameObject Spawn()
        {
            var bulletObj = Object.Instantiate(_spawnPrefab, _spawnPoint.position, _spawnPoint.rotation);
            var bullet = bulletObj.GetComponent<Bullet>();
            bullet.Init(5, 10f);

            //Invoke(nameof(Reloading), _cooldown);
            // nameof - ������ ����� � ������� ������� ������ Reloading, ��������� ��� � ������

            return bulletObj;
        }
    }
}

