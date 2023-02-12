using RoboRyanTron.Events;
using UnityEngine;
using UnityEngine.Events;

public class Score : GameEventListener
{
    [SerializeField] private HourGlassTimer timer;
    
    [SerializeField] private UnityEvent<float> newHighScoreEvent;
    
    private const string HighScoreRef = "BestTime";

    public static float BestTime
    {
        get => PlayerPrefs.GetFloat(HighScoreRef, -1f);
        private set => PlayerPrefs.SetFloat(HighScoreRef, value);
    }

    public float CurrentScore => timer.TimeTaken;
    
    public void CheckForHighScore()
    {
        if (BestTime <= 0f)
            BestTime = CurrentScore;
        
        if(CurrentScore >= BestTime)
            return;
        
        newHighScoreEvent?.Invoke(CurrentScore);
        BestTime = CurrentScore;
    }
}