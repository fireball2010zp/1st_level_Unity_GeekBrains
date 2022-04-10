using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstProject
{
    public class DontDestroySound : MonoBehaviour
    {
        public static DontDestroySound instance;

        // Start is called before the first frame update
        void Start()
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            
        }

    }
}


