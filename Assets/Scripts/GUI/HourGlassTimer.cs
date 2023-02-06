using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HourGlassTimer : MonoBehaviour
{
    [SerializeField] private Image sandFillImage;
    
    public bool HasElapsed { get; set; }
    public UnityEvent OnTimerElapsed = new UnityEvent();
    public int Duration { get; private set; }
    
    internal bool pauseTimer = false;
    
    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        sandFillImage.fillAmount = 0f;
        Duration = remainingDuration = 0;
    }

    public HourGlassTimer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            if (pauseTimer)
            {
                yield return new WaitForSeconds(10f);
                pauseTimer = false;
            }
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI( int seconds)
    {
        sandFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        ResetTimer();
        OnTimerElapsed.Invoke();
    }

    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
