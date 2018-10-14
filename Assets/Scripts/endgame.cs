using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endgame : MonoBehaviour {

    public GameObject endButton;
    public GameObject endText;
    public GameObject back;
    public GameObject endScoreText;
    public GameObject highScoreText;
    public bool endGame;
    int saveScore = 0;
    // Use this for initialization
    void Start () {
        endGame = false;
        highScoreText.GetComponent<Text> ().text = "Your Highscore: " + PlayerPrefs.GetInt ("HighScore", 0).ToString ();
    }

    // Update is called once per frame
    void Update () { }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            saveScore = GameObject.Find ("BackGround").GetComponent<Scrolling> ().way;
            endScoreText.GetComponent<Text> ().text = "Your Score: " + saveScore.ToString ();
            if (saveScore > PlayerPrefs.GetInt ("HighScore", 0)) {
                PlayerPrefs.SetInt ("HighScore", saveScore);
                highScoreText.GetComponent<Text> ().text = "Your Highscore: " + saveScore.ToString ();
            }
            highScoreText.SetActive (true);
            endScoreText.SetActive (true);
            endButton.SetActive (true);
            endText.SetActive (true);
            back.SetActive (true);
            endGame = true;
        }
    }

}