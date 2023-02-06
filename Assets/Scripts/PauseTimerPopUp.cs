using UnityEngine;

public class PauseTimerPopUp : MonoBehaviour
{
    [SerializeField] private HourGlassTimer hourGlassTimer;
    [SerializeField] private float rotationSpeed = 0.5f; // added a rotation speed variable

    private void Update()
    {
        Debug.Log("Update function called");
        transform.Rotate(0f, rotationSpeed, 0f); // rotate the game object each frame
    }

    public void PauseTime()
    {
        hourGlassTimer.pauseTimer = true;
        Destroy(gameObject);
    }
}