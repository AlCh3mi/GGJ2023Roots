using UnityEngine;

public class ConsoleDebug : MonoBehaviour
{
    public void Log(string value) => Debug.Log(value);
    public void Error(string value) => Debug.LogError(value);
}