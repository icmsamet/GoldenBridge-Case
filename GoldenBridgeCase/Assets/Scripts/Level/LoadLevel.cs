using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LoadLevel : MonoBehaviour
    {
        [SerializeField] GameObject levelPrefab;

        private void Start()
        {
            Instantiate(levelPrefab);
        }
    }
}
