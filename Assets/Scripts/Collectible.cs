using RoboRyanTron.Events;
using UnityEngine;

public class Collectible : MonoBehaviour, ICollectibles
{
    [SerializeField] private GameEvent collectedEvent;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ICollector>(out _))
            Collect();
    }

    public void Collect()
    {
        collectedEvent.Raise();
        gameObject.SetActive(false);
    }
}