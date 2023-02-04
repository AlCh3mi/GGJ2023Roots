using System;
using UnityEngine;
using UnityEngine.Events;

namespace StarterAssets
{
    public class TriggerCallbacks : MonoBehaviour
    {
        [SerializeField] private bool playerOnly;
        
        public UnityEvent TriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if(!playerOnly)
            {
                TriggerEnter?.Invoke();
                return;
            }        
            
            if(!other.CompareTag("Player"))
                return;
            
            TriggerEnter?.Invoke();
               
        }
    }
}