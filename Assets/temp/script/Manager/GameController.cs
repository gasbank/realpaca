using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public delegate void gameStartCallback();
    public gameStartCallback onGameStart;
    public delegate void gameStopCallback();
    public gameStopCallback onGameStop;
    private void Awake() {
        instance = this;
    }

    public void gameStart() {
        onGameStart();
    }

    public void gameStop() {
        onGameStop();
    }
}
