using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public int stopwatch = 300; //5 minute default time
    
    [SerializeField] private HourGlassTimer _timer;

    void Start()
    {
        _timer.SetDuration(stopwatch).Begin();
        _timer.OnTimerElapsed.AddListener(LoadGameOverScene);
    }

    void Update()
    {
        if (_timer.HasElapsed)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
