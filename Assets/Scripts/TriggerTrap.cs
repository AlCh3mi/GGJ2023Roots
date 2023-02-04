using System.Collections;
using StarterAssets;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField] private FirstPersonController playerControl;
    public void Trigger()
    {
        Debug.Log("Trap Triggered");
        playerControl.MoveSpeed = 1.0f;
        StartCoroutine(TrapDuration());
    }

    private IEnumerator TrapDuration()
    {
        yield return new WaitForSeconds(5);
        playerControl.MoveSpeed = 4.0f;
        Destroy(gameObject);
    }
}

