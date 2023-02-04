using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HourGlassTimer : MonoBehaviour
{
    [SerializeField] private Image sandFillImage;
    internal bool pauseTimer = false;
    public int Duration { get; private set; }
    
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
                Debug.Log("Timer Paused");
                yield return new WaitForSeconds(10f);
                pauseTimer = false;
                Debug.Log(pauseTimer);
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
    }

    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
