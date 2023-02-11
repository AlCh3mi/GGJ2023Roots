using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HourGlassUI : MonoBehaviour
{
    [SerializeField] private HourGlassTimer timer;
    [SerializeField] private Image hourGlassIcon;

    [SerializeField] private Color freezeColor;
    [SerializeField] private Vector3 punch = Vector3.forward * 135;

    private Color sandColor;
    
    private void Start()
    {
        sandColor = hourGlassIcon.color;
    }

    private void OnEnable()
    {
        timer.remainingDurationUpdatedEvent.AddListener(OnRemainingDurationUpdated);
        timer.timePausedEvent.AddListener(OnTimePaused);
        timer.timesUpEvent.AddListener(OnTimesUp);
    }

    private void OnDisable()
    {
        timer.remainingDurationUpdatedEvent.RemoveListener(OnRemainingDurationUpdated);
        timer.timePausedEvent.RemoveListener(OnTimePaused);
        timer.timesUpEvent.RemoveListener(OnTimesUp);
    }
    
    private void OnRemainingDurationUpdated(float remainingDuration, float duration)
    {
        hourGlassIcon.color = sandColor;
        hourGlassIcon.fillAmount = Mathf.InverseLerp(0f, duration, remainingDuration);
    }

    private void OnTimePaused()
    {
        hourGlassIcon.color = freezeColor;
        if (transform.gameObject.TryGetComponent<RectTransform>(out var rect))
            rect.DOPunchRotation(punch, 10f);
    }
    
    private void OnTimesUp() => SceneManager.LoadScene("GameOver");
}