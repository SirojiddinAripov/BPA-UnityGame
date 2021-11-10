using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //general behaviors
{
    private enum state{ //init game state
        pause,
        play,
        dead,
        menu,
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject); //keeps manager open indefinitely
    }
}