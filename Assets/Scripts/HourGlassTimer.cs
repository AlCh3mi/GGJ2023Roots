using UnityEngine;
using UnityEngine.Events;

public class HourGlassTimer : MonoBehaviour
{
    [SerializeField] private bool startWhenGameStarts;
    [SerializeField] private float startingTime;
    
    public UnityEvent<float, float> remainingDurationUpdatedEvent;
    public UnityEvent<float> pauseTimeUpdatedEvent;
    public UnityEvent timePausedEvent;
    public UnityEvent timesUpEvent;

    private float pauseTime = 0f;
    public float PauseTime
    {
        get => pauseTime;
        private set
        {
            pauseTime = Mathf.Clamp(value, 0f, float.MaxValue);
            pauseTimeUpdatedEvent?.Invoke(pauseTime);
        }
    }

    private float remainingDuration;
    public float RemainingDuration
    {
        get => remainingDuration;
        private set
        {
            remainingDuration = Mathf.Clamp(value, 0f, float.MaxValue);
            remainingDurationUpdatedEvent?.Invoke(remainingDuration, Duration);
            
            if(remainingDuration <= 0f && IsRunning && !IsPaused)
            {
                timesUpEvent?.Invoke();
                Stop();
            }
        }
    }
    
    public float Duration { get; private set; }

    public float TimeTaken => Duration - RemainingDuration;
    
    public bool IsRunning { get; private set; }
    
    public bool IsPaused => PauseTime > 0f;

    private void Start()
    {
        ResetTimer();
        
        if(startWhenGameStarts)
            Begin();
    }

    private void ResetTimer()
    {
        SetDuration(startingTime);
        RemainingDuration = Duration;
        PauseTime = 0f;
        IsRunning = false;
    }

    public void SetDuration(float seconds)
    {
        Duration = seconds;
    }

    public void Begin()
    {
        if(Duration > 0f)
            IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void Pause(float time)
    {
        if(!IsPaused)
            timePausedEvent?.Invoke();
        
        PauseTime += time;
    }

    private void Update()
    {
        if(!IsRunning)
            return;

        if (IsPaused)
        {
            PauseTime -= Time.deltaTime;
            return;
        }
    
        RemainingDuration -= Time.deltaTime;
    }
}