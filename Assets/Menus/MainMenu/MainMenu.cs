using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public SceneControl sc;
    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame(){
        sc.resumeGame();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed By User.");
    }
}
