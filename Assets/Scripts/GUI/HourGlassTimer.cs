using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HourGlassTimer : MonoBehaviour
{
    [SerializeField] private Image sandFillImage;
    internal bool pauseTimer = false;
    public int Duration => remainingDuration;
    public UnityEvent OnTimerEnd;
    
    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        sandFillImage.fillAmount = 0f;
        remainingDuration = 0;
    }

    public HourGlassTimer SetDuration(int seconds)
    {
        remainingDuration = seconds;
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
                Debug.Log("Timer Paused");
                yield return new WaitForSeconds(10f);
                pauseTimer = false;
                Debug.Log("Resume countdown");
            }
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnTimerEnd.Invoke();
    }

    private void UpdateUI(int seconds)
    {
        sandFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }
}