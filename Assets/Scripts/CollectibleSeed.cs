using StarterAssets;
using RoboRyanTron.Events;
using UnityEngine;

public class CollectibleSeed : MonoBehaviour, ICollectibles
{
    [SerializeField] private GameEvent seedCollected;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }

    public void Collect(GameObject player)
    {
        if (player.CompareTag("Player"))
        {
            seedCollected.Raise();
            gameObject.SetActive(false);
        }
    }
}
