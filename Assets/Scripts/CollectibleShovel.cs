using StarterAssets;
using System;
using UnityEngine;

public class CollectibleShovel : MonoBehaviour, ICollectibles
{
    private bool collected = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected)
        {
            Collect(collision.gameObject);
        }
    }

    public void Collect(GameObject player)
    {
        collected = true;
        Debug.Log("Collected");
        if (player.TryGetComponent<ICollector>(out var collector))
        {
            collector.HasShovel = true;
            gameObject.SetActive(false);
        }
    }
}