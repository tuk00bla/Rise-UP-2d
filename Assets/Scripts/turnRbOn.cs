using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRbOn : MonoBehaviour {

	public Rigidbody2D rb;
	public Vector2 zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity != Vector2.zero)
		{
			rb.gravityScale = 1;
		}
	}
}
