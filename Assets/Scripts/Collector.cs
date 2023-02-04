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
        
        public bool HasSeed { get; private set; }

        public void SetSeedAcquired(bool value)
        {
            HasSeed = value;
        }
        
        public bool HasWater { get; private set; }

        public void SetWaterAcquired(bool value)
        {
            HasWater = value;
        }
    }
}