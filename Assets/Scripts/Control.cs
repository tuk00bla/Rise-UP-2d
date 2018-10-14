using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	public Rigidbody2D rb;
	[SerializeField] private Vector2? lastMousePoz;
	[SerializeField] private Vector2 newMousePoz;
	[SerializeField] private bool isMove;
	private float x, y;
	public Vector2 vec1;
	public Vector2 vec2;
	public float leftPos;
	public float rightPos;
	public float upPos;
	public float downPos;
	[SerializeField] private float speed = 40;

	private void Start () {
		rightPos = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0)).x;
		leftPos = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0)).x;
		downPos = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0)).y;
		upPos = Camera.main.ScreenToWorldPoint (new Vector2 (0, Screen.height)).y;
	}

	public void OnClickDown () {
		isMove = true;
	}

	public void OnClickUp () {
		isMove = false;
		rb.velocity = Vector2.zero;
		lastMousePoz = null;
	}

	// Use this for initialization
	void FixedUpdate () {
		if (isMove) {
			newMousePoz = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (lastMousePoz == null) {
				lastMousePoz = newMousePoz;
			} else {
				x = (newMousePoz.x - lastMousePoz.Value.x) * speed;
				y = (newMousePoz.y - lastMousePoz.Value.y) * speed;
				Vector2 moveHero = new Vector2 (x, y);
				rb.velocity = moveHero;
				lastMousePoz = newMousePoz;
			}
			if (rb.position.x < leftPos || rb.position.x > rightPos) {
				isMove = false;
				rb.velocity = Vector2.zero;
				lastMousePoz = newMousePoz;
				if (rb.position.x > rightPos)
					rb.position = new Vector2 ((rightPos - 0.1f), rb.position.y);
				else if (rb.position.x < leftPos)
					rb.position = new Vector2 ((leftPos + 0.1f), rb.position.y);
			}
			if (rb.position.y > upPos || rb.position.y < downPos) {
				isMove = false;
				rb.velocity = Vector2.zero;
				lastMousePoz = newMousePoz;
				if (rb.position.y > upPos)
					rb.position = new Vector2 (rb.position.x, (upPos - 0.1f));
				else if (rb.position.y < downPos)
					rb.position = new Vector2 (rb.position.x, (downPos + 0.1f));
			}
		}
		if (GameObject.Find ("Victim").GetComponent<endgame> ().endGame == true) {
			isMove = false;
			rb.velocity = Vector2.zero;
		}
	}
}