using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public abstract class WeaponFabric // единственная ответственность - создать объект
    {
        protected GameObject _spawnPrefab;
        protected Transform _spawnPoint;

        public WeaponFabric(GameObject spawnPrefab, Transform spawnPoint) //конструктор
        {
            _spawnPoint = spawnPoint;
            _spawnPrefab = spawnPrefab;
        }

        public abstract GameObject Spawn();


    }
}

