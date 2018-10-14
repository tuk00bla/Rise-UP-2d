using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour {

	public float speed = 2;
	public List<SpriteRenderer> sprites = new List<SpriteRenderer> ();
	public Direction Dir = Direction.Down;
	private float heightCamera;
	public int score = 0;
	public int way = 0;
	private Camera cam;
	public Text scoreText;
	private void Awake () {
		cam = Camera.main;
		heightCamera = 2f * cam.orthographicSize;

	}

	void Update () {
		score++;
		way = Mathf.RoundToInt ((Time.timeSinceLevelLoad * speed) * 3);
		scoreText.text = way.ToString ();
		foreach (var item in sprites) {
			if (Dir == Direction.Down) {
				if (item.transform.position.y + item.bounds.size.y / 2 < cam.transform.position.x - heightCamera / 2) {
					SpriteRenderer sprite = sprites[0];
					foreach (var i in sprites) {
						if (i.transform.position.y > sprite.transform.position.y)
							sprite = i;
					}
					item.transform.position = new Vector2 (sprite.transform.position.x, (sprite.transform.position.y + (sprite.bounds.size.y / 2) + (item.bounds.size.y / 2)));
				}
			} else if (Dir == Direction.Up) {
				if (item.transform.position.y - item.bounds.size.y / 2 > cam.transform.position.y + heightCamera / 2) {
					SpriteRenderer sprite = sprites[0];
					foreach (var i in sprites) {
						if (i.transform.position.y < sprite.transform.position.y)
							sprite = i;
					}
					item.transform.position = new Vector2 (sprite.transform.position.x, (sprite.transform.position.y - (sprite.bounds.size.y / 2) - (item.bounds.size.y / 2)));
				}
			}
			if (Dir == Direction.Down)
				item.transform.Translate (new Vector2 (Time.deltaTime * speed * -1, 0));
			else if (Dir == Direction.Up)
				item.transform.Translate (new Vector2 (Time.deltaTime * speed, 0));
		}
		if (GameObject.Find ("Victim").GetComponent<endgame> ().endGame == true) {
			speed = 0;
			scoreText.enabled = false;
		}
	}

	/*void OnGUI () {
		UnityEngine.UI.CanvasScaler c = GetComponent<UnityEngine.UI.CanvasScaler> ();
		c.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height * 0.09f), "Distance: " + Mathf.RoundToInt (score / 10));
	} */
}

public enum Direction {
	Up,
	Down
}