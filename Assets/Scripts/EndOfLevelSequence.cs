using System.Collections;
using RoboRyanTron.Events;
using UnityEngine;
using UnityEngine.Events;

public class EndOfLevelSequence : GameEventListener
{
    [SerializeField] private float waitTime = 15f;
    [SerializeField] private UnityEvent postDelayEvent;
    
    public void StartEndSequence() => StartCoroutine(DelayEndOfLevel());
    
    private IEnumerator DelayEndOfLevel()
    {
        yield return new WaitForSeconds(waitTime);
        postDelayEvent?.Invoke();        
    }
}