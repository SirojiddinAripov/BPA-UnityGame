using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public int sceneToLoad;
    public Vector3 playerPos;
    public PlayerStats stats;
    public Player player;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !other.isTrigger){
            SceneManager.LoadScene(sceneToLoad);
            stats.playerCoords = playerPos;
            stats.playerHealth = player.Health;
            stats.playerMana = player.Mana;
        }
    }
}
