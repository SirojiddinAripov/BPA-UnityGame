using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private void Awake() {
        SceneManager.LoadScene(1);
    }

    public void startGame(){
        SceneManager.LoadScene(2);
    }

    public void resumeGame(){
        //get scene data from JSON
    }

    public void pause(){
        //save scene state to json
        //load pause menu
    }

    public void quitToMenu(){
        //remind to save
        //if confirmed - SceneManager.LoadScene(1);
    }
}
