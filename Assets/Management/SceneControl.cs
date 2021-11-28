using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
public PlayerStats stats;
public Player player;

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

    public void changeScene(int x){
        SceneManager.LoadScene(x);
    }

    public void Pause(){
        stats.playerCoords = player.transform.position;
        stats.playerHealth = player.Health;
        stats.playerMana = player.Mana;
        SceneManager.LoadScene(2);
    }
}
