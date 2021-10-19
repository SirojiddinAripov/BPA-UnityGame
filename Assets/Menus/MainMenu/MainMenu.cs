using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //opens begining of game and ignores player state
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed By User.");
    }
}
