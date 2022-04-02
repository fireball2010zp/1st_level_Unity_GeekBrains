using MyFirstProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFirstProject
{
    public class Waypoint : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform[] waypoints;

        int m_CurrentWaypointIndex;

        [SerializeField] public Transform spawnPosition;
        [SerializeField] private Player _player;

        private bool patrolling = true;

        [SerializeField] private float _speedRotate = 10;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            navMeshAgent.SetDestination(waypoints[0].position);
        }

        void Update()
        {
            if ((navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) && patrolling)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                // держит индекс от 0 до 3, не позволяя выйти за пределы индекса массива
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }

            Ray ray = new Ray(spawnPosition.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 10))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    patrolling = false;
                    StartCoroutine(AgentMode());
                }
                /*if (!hit.collider.CompareTag("Player"))
                {
                    patrolling = true;
                    StopCoroutine(AgentMode());

                }*/
            }
        }

        private IEnumerator AgentMode()
        {
            navMeshAgent.SetDestination(_player.transform.position);

            // реализация наблюдения за игроком
            var direction = _player.transform.position - spawnPosition.position;
            direction.Set(direction.x, 0, direction.z);
            var stepRotate = Vector3.RotateTowards(transform.forward,
                direction, _speedRotate * Time.fixedDeltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(stepRotate);

            Ray ray = new Ray(spawnPosition.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 10))
            {
                if (!hit.collider.CompareTag("Player"))
                {
                    patrolling = true;
                    yield return new WaitForSeconds(5);
                }
            }
            
        }
    }

}
