using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Transitions : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPos;
    public PlayerCoords coords;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !other.isTrigger){
            EditorSceneManager.LoadScene(sceneToLoad);
            coords.initValue = playerPos;
        }
    }
}
