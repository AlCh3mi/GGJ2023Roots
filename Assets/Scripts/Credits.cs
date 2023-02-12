using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private float displayTime = 30f;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(displayTime);
        SceneManager.LoadScene("StartPage");
    }
}
