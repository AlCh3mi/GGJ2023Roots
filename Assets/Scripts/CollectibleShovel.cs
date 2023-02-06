using StarterAssets;
using System;
using RoboRyanTron.Events;
using UnityEngine;

public class CollectibleShovel : MonoBehaviour, ICollectibles
{
    [SerializeField] private GameEvent shovelCollected;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }

    public void Collect(GameObject player)
    {
        Debug.Log("Collected");
        if (player.CompareTag("Player"))
        {
            shovelCollected.Raise();
            gameObject.SetActive(false);
        }
    }
}