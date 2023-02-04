using UnityEngine;
using UnityEngine.Events;

namespace StarterAssets
{
    public class Collector : MonoBehaviour, ICollector
    {
        public UnityEvent<bool> shovelCollected;

        private bool _hasShovel;
        public bool HasShovel
        {
            get => _hasShovel;
            set
            {
                _hasShovel = value;
                shovelCollected?.Invoke(value);
            }
        }
    }
}