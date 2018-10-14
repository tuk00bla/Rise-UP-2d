using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour {

    public GameObject Enmy;
    public GameObject GroupEnmy;
    public GameObject Lvl3;
    public GameObject Lvl4;
    public float startTime;
    public GameObject Barrier;
    public float x, y;
    public float sec;
    public Vector2 coord;
    public Vector2? oldcoord;
    private int nextLevel = 0;
    public float nextTime;
    public float rightPos, leftPos;

    void Start () {
        rightPos = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0)).x;
        leftPos = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0)).x;
        Debug.Log ("LeftPos: " + leftPos);
        Debug.Log ("RightPos: " + rightPos);
        StartCoroutine (ChangeLevel ());
        StartCoroutine (SpawnEnemy ());
    }

    void Update () {
        startTime = Time.time;
        if (GameObject.Find ("Victim").GetComponent<endgame> ().endGame == true) {
            StopAllCoroutines ();
        }
    }

    IEnumerator SpawnEnemy () {
        while (true) {
            switch (nextLevel) {
                case 1:
                    {
                        x = Random.Range (leftPos, rightPos);
                        y = Random.Range (6, 10);
                        sec = Random.Range (5, 7);
                        coord = new Vector2 (x, y);
                        Instantiate (Enmy, coord, Quaternion.identity);
                        break;
                    }
                case 2:
                    {
                        x = (Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0)).x / 2);
                        y = transform.position.y;
                        sec = Random.Range (5, 7);
                        coord = new Vector2 (x, y);
                        Instantiate (GroupEnmy, coord, Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        sec = Random.Range (5, 7);
                        coord = transform.position;
                        Instantiate (Barrier, coord, Quaternion.identity);
                        break;
                    }
                case 4:
                    {
                        sec = 35;
                        coord = transform.position;
                        Instantiate (Lvl3, coord, Quaternion.identity);
                        break;
                    }
                case 5:
                    {
                        sec = 40;
                        coord = transform.position;
                        Instantiate (Lvl4, coord, Quaternion.identity);
                        break;
                    }

            }
            yield return new WaitForSeconds (sec);
        }
    }

    IEnumerator ChangeLevel () {
        while (true) {
            float secnd = 10;
            if (startTime == 0) {
                nextLevel = 1;
            } else {
                if (nextLevel == 4) {
                    secnd = 35;
                }

                if (nextLevel > 5) {
                    nextLevel = 0;
                }
                nextLevel++;
                Debug.Log ("Next level: " + nextLevel);
            }
            yield return new WaitForSeconds (secnd);
        }
        /*    for (nextLevel = 1; nextLevel <= 6; nextLevel++)
            {
                float secnd = 10;
                if (startTime == 0)
                {
                    nextLevel = 1;
                }
                if (nextLevel == 5)
                {
                    secnd = 60;
                    nextLevel = 1;
                    yield return new WaitForSeconds(secnd);
                }
                Debug.Log("NextLevel" + nextLevel);
            yield return new WaitForSeconds(secnd);
        } */
    }
}