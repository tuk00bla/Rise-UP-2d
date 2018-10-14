using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObject : MonoBehaviour {

	public GameObject Hero;
	public GameObject Barrier;
	public GameObject Enemy_Barrier;
	public GameObject Ignoring;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    /*      Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), Ignoring.GetComponent<Collider2D>());
		  Physics2D.IgnoreCollision(Barrier.GetComponent<Collider2D>(), Ignoring.GetComponent<Collider2D>());
		  Physics2D.IgnoreCollision(Enemy_Barrier.GetComponent<Collider2D>(), Ignoring.GetComponent<Collider2D>()); */	
	}

	private void OnTriggerEnter2D(Collider2D other) {

	if (other.gameObject.tag == "Hero") 
	{
		Debug.Log("Sany");
     	Physics2D.IgnoreCollision(Hero.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    } 		
	}
 
}
