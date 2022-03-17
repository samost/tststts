using System;
using Unity.VisualScripting;
using UnityEngine;

namespace AI
{
    public class SimpleAIAlliedController: MonoBehaviour
    {
        public bool IsLive { get; set; }

        private void Awake()
        {
            IsLive = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>() != null)
            {
                this.gameObject.SetActive(false);
                IsLive = false;
            }
        }
    }
}