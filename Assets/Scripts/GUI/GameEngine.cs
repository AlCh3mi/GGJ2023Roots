using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameEngine : MonoBehaviour
{
    [FormerlySerializedAs("_timer")] [SerializeField] private HourGlassTimer timer;

    public int stopwatch = 300; //5 minute default time
    
    void Start()
    {
        timer.SetDuration(stopwatch).Begin();
        timer.onTimerEnd.AddListener(HandleTimerEnd);
    }
    
    private void HandleTimerEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
}