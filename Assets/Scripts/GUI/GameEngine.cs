using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    [SerializeField] private HourGlassTimer _timer;

    public int stopwatch = 300; //5 minute default time
    

    void Start()
    {
        _timer.SetDuration(stopwatch).Begin();
        _timer.OnTimerEnd.AddListener(HandleTimerEnd);
    }


    void Update()
    {
        
    }

    private void HandleTimerEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
}