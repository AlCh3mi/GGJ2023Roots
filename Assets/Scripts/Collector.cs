using RoboRyanTron.Events;
using UnityEngine;
using UnityEngine.Events;

namespace StarterAssets
{
    public class Collector : MonoBehaviour, ICollector
    {
        public bool HasShovel { get; private set; }

        public void SetShovelAcquired(bool value)
        {
            HasShovel = value;
        }
    }
}