using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	
    public Vector2 startPosition;
	public Rigidbody2D rgbd;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x, transform.position.y - 1*Time.deltaTime);
	}
}
