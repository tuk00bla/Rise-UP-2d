using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class govno : MonoBehaviour {
	public Rigidbody2D rb;
	[SerializeField] private Vector2? lastMousePoz;
	[SerializeField] private Vector2 newMousePoz;
	[SerializeField] private bool isMove;
	private float x, y;
	public float speed = 50;

	
 	public void OnClickDown()
	{
		isMove = true;
	}

	public void OnClickUp()
	{
		isMove = false;
		rb.velocity = Vector2.zero;
		lastMousePoz = null;
	}

	// Use this for initialization
	void FixedUpdate () 
	{
		if (isMove)
		{
			newMousePoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (lastMousePoz == null)
			{
				lastMousePoz = newMousePoz;
			}

			else
			{
				x = (newMousePoz.x - lastMousePoz.Value.x) * speed;
				y = (newMousePoz.y - lastMousePoz.Value.y) * speed;
				Vector2 moveHero = new Vector2(x,y);
				rb.velocity = moveHero;
				lastMousePoz = newMousePoz;
			}
		}
	}
}