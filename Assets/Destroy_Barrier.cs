using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Barrier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Barrier")
            {
                Destroy(other.gameObject);
            }
		if (other.gameObject.tag == "Spawn_Ball")
		{
		GameObject.Find("SpawnBallLeft").GetComponent<SpawnBall>().enabled = false;
		GameObject.Find("SpawnBallRight").GetComponent<SpawnBallRight>().enabled = false;
		}
	}
}
