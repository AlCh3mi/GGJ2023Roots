using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassTestSystem : MonoBehaviour
{
    [SerializeField] private HourGlassTimer _timer;

    public int stopwatch = 10;
    // Start is called before the first frame update
    void Start()
    {
        _timer.SetDuration(stopwatch).Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
