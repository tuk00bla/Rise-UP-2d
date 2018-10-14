using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class newgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void OnMouseDown() {
        SceneManager.LoadScene(1);    
    }

	public void BackToTheMenu()
	{
		SceneManager.LoadScene(0);
	}

}
