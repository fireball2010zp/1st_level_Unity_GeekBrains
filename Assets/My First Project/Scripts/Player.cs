using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyFirstProject
{
    public class Player : MonoBehaviour // вешает класс на наш объект
                                        // у MonoBehaviour конструктор закрыт
    {
        public GameObject shieldPrefab;   // объект - щит
        public Transform spawnPosition;   // позици€ щита в пространстве и его размеры



        private bool _isSpawnShield;
        [HideInInspector] private int level = 1;
        // [HideInInspector] - атрибут дл€ скрыти€ в инспекторе кода Unity

        // параметры дл€ перемещени€ (Vector2 - массив с двум€ параметрами)
        private Vector3 _direction;
        public float speed = 2f;
        // Vector1 - ось X (вправо), Vector2 - ось Y (вверх), Vector3 - ось Z (вперЄд)

        private bool _isSprint;

        void Awake()
        {
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            // провер€ем нажатие левой кнопки мыши
            if (Input.GetMouseButtonDown(1)) // Down - при нажатии, Up - при отжатии
                _isSpawnShield = true;
            // этот метод работает и дл€ тапов на моб платформах

            _direction.x = (Input.GetAxis("Horizontal"));
            _direction.z = (Input.GetAxis("Vertical"));

            /*
            // провер€ем нажатие клавиш на клавиатуре (направление движени€)
            if (Input.GetKey(KeyCode.W))
                _direction.z = 1; // ось Z отвечает за направление вперЄд
            else if (Input.GetKey(KeyCode.S))
                _direction.z = -1;
            else 
                _direction.z = 0;
            */

            _isSprint = (Input.GetButton("Sprint"));


        }

        void FixedUpdate()
        {
            if (_isSpawnShield)
            {
                _isSpawnShield = false;
                SpawnShield();
            }

            Move(Time.fixedDeltaTime);
            // стандартное значение fixedDeltaTime = 0,2с
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            // Instantiate - возвращает ссылку на объект
            // (Unity через свой внутренний конструктор New создаЄт объект)
            // щит создастс€ в координатах указанных в Prefab'е shieldPrefab
            // spawnPosition.position - координаты
            // spawnPosition.rotation - повотор щита вместе с объектом

            var shield = shieldObj.GetComponent<Shield>();
            // в методе GetComponent в скобках указываем ссылку на экземпл€р класса который ищем
            // и в переменную shield присваиваем все компоненты класса Shield
            // ещЄ вместо <Shield> можно указать <Transform>

            shield.Init(10 * level);
            // прочность щита будет увеличиватьс€ с ростом уровн€ сложности

            shield.transform.SetParent(spawnPosition);
            // прив€зка щита к родителю spawnPosition
        }

        // метод реализующий движение объекта
        private void Move(float delta)
        {
            transform.position += _direction * (_isSprint ? speed * 2 : speed) * delta;
            // к текущей позиции прибавл€ем прирост
        }
    }
}


/*
¬опросы
- почему не обозначаютс€ методы €рлыком Event functions (Unity functions)?
- MonoBehaviour не отображаетс€ как наследуемый класс (родитель)



‘ункции Awake() и Start() относ€тс€ к блоку инициализации жизненного цикла скрипта
FixedUpdate() - блок физики (зависит от предустановленного значени€ времени), выполн€етс€ каждый фиксированный отрезок времени (настройка в Edit Ч Project Settings Ч Time Ч Fixed Timestep)
Update() и LateUpdate() - блок игровой логики (котора€ зависит от fps)

ѕор€док вызовов:

1. Awake()
2. OnEnable()
3. Start()

4. Update()
5. LateUpdate()

*/

