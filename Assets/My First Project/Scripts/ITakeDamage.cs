using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{ 
    // интерфейс содержит названия поведений объектов
    public interface ITakeDamage
    {
        public void Hit(float damage);
        // все классы, которые наследуют интерфейс ITakeDamage должны иметь в себе метод Hit
    }
}


