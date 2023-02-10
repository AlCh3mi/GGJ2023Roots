using StarterAssets;
using RoboRyanTron.Events;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private CollectibleShovel shovel;
    [SerializeField] private CollectibleSeed seed;
    [SerializeField] private CollectibleWater water;

    private bool shovelCollected = false;
    private bool seedCollected = false;
    private bool waterCollected = false;

    private void Start()
    {
        shovel.gameObject.SetActive(true);
        seed.gameObject.SetActive(false);
        water.gameObject.SetActive(false);

        GameEventListener shovelListener = gameObject.AddComponent<GameEventListener>();
        shovelListener.Event = shovel.shovelCollected;
        shovelListener.Response.AddListener(HandleShovelCollected);

        GameEventListener seedListener = gameObject.AddComponent<GameEventListener>();
        seedListener.Event = seed.seedCollected;
        seedListener.Response.AddListener(HandleSeedCollected);

        GameEventListener waterListener = gameObject.AddComponent<GameEventListener>();
        waterListener.Event = water.waterCollected;
        waterListener.Response.AddListener(HandleWaterCollected);
    }

    private void HandleShovelCollected()
    {
        shovelCollected = true;
        seed.gameObject.SetActive(true);
    }

    private void HandleSeedCollected()
    {
        seedCollected = true;
        water.gameObject.SetActive(true);
    }

    private void HandleWaterCollected()
    {
        waterCollected = true;
    }
}