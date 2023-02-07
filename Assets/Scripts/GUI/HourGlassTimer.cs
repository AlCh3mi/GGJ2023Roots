using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class HourGlassTimer : MonoBehaviour
{
    [SerializeField] private Image sandFillImage;
    internal bool PauseTimer = false;
    public int Duration => _remainingDuration;
    [FormerlySerializedAs("OnTimerEnd")] public UnityEvent onTimerEnd;
    
    private int _remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        sandFillImage.fillAmount = 0f;
        _remainingDuration = 0;
    }

    public HourGlassTimer SetDuration(int seconds)
    {
        _remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (_remainingDuration > 0)
        {
            if (PauseTimer)
            {
                Debug.Log("Timer Paused");
                yield return new WaitForSeconds(10f);
                PauseTimer = false;
                Debug.Log("Resume countdown");
            }
            UpdateUI(_remainingDuration);
            _remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        onTimerEnd.Invoke();
    }

    private void UpdateUI(int seconds)
    {
        sandFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }
}