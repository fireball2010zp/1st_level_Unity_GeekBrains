using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    // скрипт щита в самом Prefab'e

    // сначала вызываетс€ конструктор у родительского класса MonoBehaviour
    // затем вызываетс€ конструктор у класса Shield

    public class Shield : MonoBehaviour
    {
        [SerializeField] private float _durability; // прочность щита
                                                    // аттрибут [SerializeField] используетс€ дл€ видимости в настройках Unity
                                                    // свойства Durability

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 3f); // щит будет жить 3 секунды после по€влени€
        }

    }
}

