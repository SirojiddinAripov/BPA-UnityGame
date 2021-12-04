using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SettingsMenu sm;

    public void NewGame()
    {
        SceneManager.LoadScene(4);
    }

    public void settingsButton(){
        sm.previousScene = 1;
        SceneManager.LoadScene(3);
    }

    public void LoadGame(){
        Debug.Log(null);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed By User.");
    }
}
