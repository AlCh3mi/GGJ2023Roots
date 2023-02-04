using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Maze");
    }
    
    private void ExitGame()
    {
        SceneManager.LoadScene("Credits");
        //yield return new WaitForSeconds(5);
    }
}
