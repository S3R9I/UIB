using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public bool gameStart;
    public GameObject EndScreen;


    public float time;
    private float seconds;
    private float minutes;


    void Start() {
        time = 1800;
    }

    public void GameStart() {
        gameStart = true;
    }
    public void GameStop()
    {
        gameStart = false;
    }
    void Update() {

        if (gameStart) {
            time -= Time.deltaTime;

            minutes = (int)(time / 60);
            seconds = (int)(time % 60); //Use the euclidean division for the seconds.
            string secondsText;
            if (seconds >= 10) {
                secondsText = minutes.ToString() + ":" + seconds.ToString ();
            } else {
                secondsText = minutes.ToString() + ":0" + seconds.ToString ();

            }

            if (time < 0) {
                return;
            }

            timerText.text = secondsText;
        }
        else {
            timerText.text = "";
        }

        if (timerText.text == "0") {
            EndScreen.SetActive(true);
        }

    }
}
