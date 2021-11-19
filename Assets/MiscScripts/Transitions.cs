using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Transitions : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPos;
    public PlayerStats stats;
    public Player player;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !other.isTrigger){
            EditorSceneManager.LoadScene(sceneToLoad);
            stats.playerCoords = playerPos;
            stats.playerHealth = player.Health;
            stats.playerMana = player.Mana;
        }
    }
}
