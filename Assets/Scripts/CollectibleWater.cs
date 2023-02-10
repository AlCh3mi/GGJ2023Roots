using StarterAssets;
using RoboRyanTron.Events;
using UnityEngine;

public class CollectibleWater : MonoBehaviour, ICollectibles
{
    [SerializeField] public GameEvent waterCollected;
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
            waterCollected.Raise();
            gameObject.SetActive(false);
        }
    }
}
