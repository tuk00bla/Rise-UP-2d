using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager_Test : MonoBehaviour {
	private void Start () {
		float res_x = Screen.width;
		float res_y = Screen.height;

		Vector2 res_game = Camera.main.ScreenToWorldPoint (new Vector2 (0, res_y));
		Debug.Log (res_game);
	}
}