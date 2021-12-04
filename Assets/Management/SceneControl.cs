using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

public int prevScene;
public PlayerStats stats;
public Player player;

    private void Awake() {
        SceneManager.LoadScene(1);
    }

    public void startGame(){
        SceneManager.LoadScene(2);
    }

    public void resumeGame(){
        SceneManager.LoadScene(prevScene);
    }

    public void quitToMenu(){
        SceneManager.LoadScene(1);
    }

    public void changeScene(int x){
        SceneManager.LoadScene(x);
    }

    public void Pause(int p){
        stats.playerCoords = player.transform.position;
        stats.playerHealth = player.Health;
        stats.playerMana = player.Mana;
        prevScene = p;
        SceneManager.LoadScene(2);
    }
}
