using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform spawnPosition;

        private bool shooting = true;

        void Start()
        {
            _player = FindObjectOfType<Player>();

        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 5)
            {
                if (shooting)
                    StartCoroutine(TurrelFire());
            }
        }

        private IEnumerator TurrelFire()
        {
            shooting = false;
            Fire();
            yield return new WaitForSeconds(1);
            shooting = true;
        }

        void FixedUpdate()
        {
            // реализаци€ наблюдени€ за игроком
            var direction = _player.transform.position - transform.position;
            // результат вычитани€ векторов (игрока и туррели) будет вектор от туррели до игрока

            direction.Set(direction.x, 0, direction.z);
            // исключаем вращение турели по оси Y

            var stepRotate = Vector3.RotateTowards(transform.forward, 
                direction, _speedRotate * Time.fixedDeltaTime, 0f);
            // transform.forward - текущее направление взгл€да туррели
            // direction - конечна€ точка поворота взгл€да туррели
            // _speedRotate * Time.fixedDeltaTime Ч скорость поворота
            // 0f Ч максимальна€ длина вектора

            transform.rotation = Quaternion.LookRotation(stepRotate);
            // метод LookRotation - повернутьс€ в сторону направлени€

        }

        // метод реализации стрельбы турели
        private void Fire()
        {
            var shieldObj = Instantiate(_bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(/*_player.transform,*/ 5, 10f);
        }
    }
}


