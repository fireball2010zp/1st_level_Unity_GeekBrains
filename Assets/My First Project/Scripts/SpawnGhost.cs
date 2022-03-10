using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class SpawnGhost : MonoBehaviour
    {
        public GameObject ghostPrefab;
        public Transform spawnPosition1;

        private bool spawning = true;

        // Update is called once per frame
        void Update()
        {
            if (spawning)
                StartCoroutine(SpawnGhost1());
        }

        private IEnumerator SpawnGhost1()
        {
            spawning = false;
            Instantiate(ghostPrefab, spawnPosition1.position, spawnPosition1.rotation);
            yield return new WaitForSeconds(10);
            spawning = true;
        }
    }
}


