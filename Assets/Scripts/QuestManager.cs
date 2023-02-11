using RoboRyanTron.Events;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    [field:SerializeField] public bool HasSeed {get; private set;}
    [field:SerializeField] public bool HasWater {get; private set;}
    [field:SerializeField] public bool HasShovel {get; private set;}

    public UnityEvent allConditionsMet;

    public bool HasAllRequirements => HasSeed && HasWater && HasShovel;

    public void OnSeedCollected()
    {
        HasSeed = true;
        RequirementsCheck();
    }

    public void OnWaterCollected()
    {
        HasWater = true;
        RequirementsCheck();
    }

    public void OnShovelCollected()
    {
        HasShovel = true;
        RequirementsCheck();
    }

    private void RequirementsCheck()
    {
        if(HasAllRequirements)
            allConditionsMet?.Invoke();
    }
}