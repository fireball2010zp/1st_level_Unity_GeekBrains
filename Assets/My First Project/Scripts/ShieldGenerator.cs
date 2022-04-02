using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public sealed class ShieldGenerator : WeaponFabric // sealed - закрывает наследование
    {
        private int _level;
        public ShieldGenerator(int level, GameObject spawnPrefab, Transform spawnPoint) : base(spawnPrefab, spawnPoint)
        {
            _level = level;
        }
        public override GameObject Spawn()
        {
            var shieldObj = Object.Instantiate(_spawnPrefab, _spawnPoint.position, _spawnPoint.rotation);
            // Instantiate - возвращает ссылку на объект
            // (Unity через свой внутренний конструктор New создаЄт объект)
            // щит создастс€ в координатах указанных в Prefab'е _spawnPrefab
            // _spawnPoint.position - координаты
            // _spawnPoint.rotation - повотор щита вместе с объектом

            var shield = shieldObj.GetComponent<Shield>();
            // в методе GetComponent в скобках указываем ссылку на экземпл€р класса который ищем
            // и в переменную shield присваиваем все компоненты класса Shield
            // ещЄ вместо <Shield> можно указать <Transform>

            shield.Init(10 * _level);
            // прочность щита будет увеличиватьс€ с ростом уровн€ сложности

            shield.transform.SetParent(_spawnPoint);
            // прив€зка щита к родителю spawnPosition

            return shieldObj;
        }
    }
}

