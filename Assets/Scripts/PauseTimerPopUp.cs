using UnityEngine;

public class PauseTimerPopUp : MonoBehaviour
{
    public HourGlassTimer hourGlassTimer;
    [SerializeField] private float rotationSpeed = 0.5f; // added a rotation speed variable

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f); // rotate the game object each frame
    }

    public void PauseTime()
    {
        hourGlassTimer.PauseTimer = true;
        Debug.Log(hourGlassTimer.PauseTimer);
        Destroy(gameObject);
    }
}