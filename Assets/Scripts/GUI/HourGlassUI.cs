using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HourGlassUI : MonoBehaviour
{
    [SerializeField] private HourGlassTimer timer;
    [SerializeField] private Image hourGlassIcon;

    [SerializeField] private Color freezeColor;
    [SerializeField] private Vector3 punch = Vector3.one;

    private Color sandColor;
    
    private void Start()
    {
        sandColor = hourGlassIcon.color;
    }

    void OnEnable()
    {
        timer.remainingDurationUpdatedEvent.AddListener(OnRemainingDurationUpdated);
        timer.timePausedEvent.AddListener(OnTimePaused);
        timer.pauseTimeUpdatedEvent.AddListener(OnPauseTimeUpdated);
        timer.timesUpEvent.AddListener(OnTimesUp);
    }


    private void OnDisable()
    {
        timer.remainingDurationUpdatedEvent.RemoveListener(OnRemainingDurationUpdated);
        timer.timePausedEvent.RemoveListener(OnTimePaused);
        timer.pauseTimeUpdatedEvent.RemoveListener(OnPauseTimeUpdated);
        timer.timesUpEvent.RemoveListener(OnTimesUp);
    }
    
    private void OnRemainingDurationUpdated(float remainingDuration, float duration)
    {
        hourGlassIcon.color = sandColor;
        hourGlassIcon.fillAmount = Mathf.InverseLerp(0f, duration, remainingDuration);
    }

    private void OnPauseTimeUpdated(float remainingPauseTime)
    {
        //could show remaining pause time here, if we wanted
    }

    private void OnTimePaused()
    {
        hourGlassIcon.color = freezeColor;
        if (transform.gameObject.TryGetComponent<RectTransform>(out var rect))
        {
            rect.DOPunchRotation(punch, 10f);
        }
    }
    
    private void OnTimesUp()
    {
        SceneManager.LoadScene("GameOver");
    }
}