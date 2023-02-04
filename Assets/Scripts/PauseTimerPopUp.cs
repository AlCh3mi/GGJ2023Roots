using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Events;
using UnityEngine;
using StarterAssets;

public class PauseTimerPopUp : MonoBehaviour
{
    [SerializeField] private HourGlassTimer hourGlassTimer;

    public void PauseTime()
    {
        hourGlassTimer.pauseTimer = true;
        Destroy(gameObject);
    }
}
