using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Maze");
    }
    
    public void ExitGame()
    {
        Debug.Log("Quit Game... Thanks for playing");
        Application.Quit();
    }
}

