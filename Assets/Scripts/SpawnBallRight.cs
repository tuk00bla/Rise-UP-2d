﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallRight : MonoBehaviour {

	// Use this for initialization
    public GameObject EnemyBall;
    public float x, y;
    public float sec;
    public Vector2 coord;
	public Vector2 ballForce;
	[SerializeField] private GameObject ballInst;
	void Start () {
		StartCoroutine(SpawnEnemyBall());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		 IEnumerator SpawnEnemyBall()
    {
        while (true)
        {
			ballForce = new Vector2(-2000, 0);
            sec = 1;
            coord = transform.position;	
            ballInst = Instantiate(EnemyBall, coord, Quaternion.identity);
			ballInst.GetComponent<Rigidbody2D>().AddForce(ballForce,ForceMode2D.Impulse);
			yield return new WaitForSeconds(sec);
		}
    }
}