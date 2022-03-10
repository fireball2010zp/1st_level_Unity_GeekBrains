using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyFirstProject
{
    public class Player : MonoBehaviour // вешает класс на наш объект
                                                 // у MonoBehaviour конструктор закрыт
    {
        public GameObject shieldPrefab;   // объект - щит
        public Transform spawnPosition;   // позиция щита в пространстве и его размеры

        public GameObject minePrefab;   // объект - мина
        public Transform spawnPositionMine;   // позиция мины в пространстве

        private bool _isSpawnShield;
        private bool _isSpawnMine;

        [SerializeField] private float _ammunition = 0;

        [HideInInspector] private int level = 1;
        // [HideInInspector] - атрибут для скрытия в инспекторе кода Unity

        // параметры для перемещения (Vector2 - массив с двумя параметрами)
        private Vector3 _direction;
        public float speed = 2f;
        // Vector2 - ось X (вправо) и ось Y (вверх), Vector3 - ось Z (вперёд)

        public float speedRotate = 20f;

        private bool _isSprint;

        void Start()
        {
            /*
            var point1 = new Vector3(1f, 5f, 1462f); 
            // пример объявления вектора, может быть как точка, а может как и расстояние
            // от начала координат до заданной точки
            var point2 = new Vector3(16f, 5f, 142f);

            // пример рассчета расстояния между точками
            var dist = Vector3.Distance(point1, point2);
            Debug.Log(dist);

            // вывод длинны Vector3.down
            Debug.Log(Vector3.down.magnitude);

            // вывод длинны Vector3.one (все значения = 1)
            Debug.Log(Vector3.one.magnitude);
            */
        }

        void Update()
        {
            // проверяем нажатие левой кнопки мыши
            if (Input.GetMouseButtonDown(1)) // Down - при нажатии, Up - при отжатии
                _isSpawnShield = true;
            // этот метод работает и для тапов на моб платформах

            if (Input.GetKey(KeyCode.M))
                _isSpawnMine = true;

            _direction.x = (Input.GetAxis("Horizontal"));
            _direction.z = (Input.GetAxis("Vertical"));

            /* - расвёрнутый аналог последних двух строчек:
            // проверяем нажатие клавиш на клавиатуре (направление движения)
            if (Input.GetKey(KeyCode.W))
                _direction.z = 1; // ось Z отвечает за направление вперёд
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

            if (_isSpawnMine)
            {
                _isSpawnMine = false;
                SpawnMine();
            }

            Move(Time.fixedDeltaTime);
            // стандартное значение fixedDeltaTime = 0,2с

            // поворот через мышку
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }

        private void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, spawnPosition.position, spawnPosition.rotation);
            // Instantiate - возвращает ссылку на объект
            // (Unity через свой внутренний конструктор New создаёт объект)
            // щит создастся в координатах указанных в Prefab'е shieldPrefab
            // spawnPosition.position - координаты
            // spawnPosition.rotation - повотор щита вместе с объектом

            var shield = shieldObj.GetComponent<Shield>();
            // в методе GetComponent в скобках указываем ссылку на экземпляр класса который ищем
            // и в переменную shield присваиваем все компоненты класса Shield
            // ещё вместо <Shield> можно указать <Transform>

            shield.Init(10 * level);
            // прочность щита будет увеличиваться с ростом уровня сложности

            shield.transform.SetParent(spawnPosition);
            // привязка щита к родителю spawnPosition
        }

        private void SpawnMine()
        {
            var mineObj = Instantiate(minePrefab, spawnPositionMine.position, spawnPositionMine.rotation);
            var mine = mineObj.GetComponent<Mine>();
        }

        // метод реализующий движение объекта
        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;
            // к текущей позиции прибавляем прирост
            // .normalized (либо метод Normalize) - приведение значения magnitude (вектора Vector3)
            // к 1 при нажатии двух кнопок направлений (по умолчанию magnitude z+x = 1.73,
            // поэтому по диагонали движение объекта ускоряется)
        }

        private void OnTriggerStay(Collider other)
        { 

            if (other.gameObject.tag == "Ammo")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _ammunition += 10;
                    Debug.Log(message: "You got 10 bullets!");
                }
            }
        }
    }
}


/*
Вопросы
- почему не обозначаются методы ярлыком Event functions (Unity functions)?
- MonoBehaviour не отображается как наследуемый класс (родитель)



Функции Awake() и Start() относятся к блоку инициализации жизненного цикла скрипта
FixedUpdate() - блок физики (зависит от предустановленного значения времени), выполняется каждый фиксированный отрезок времени (настройка в Edit — Project Settings — Time — Fixed Timestep)
Update() и LateUpdate() - блок игровой логики (которая зависит от fps)

Порядок вызовов:

1. Awake()
2. OnEnable()
3. Start()

4. Update()
5. LateUpdate()

*/

