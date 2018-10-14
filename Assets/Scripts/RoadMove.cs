using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoadMove : MonoBehaviour {
 
        private float scrollSpeed = 3;
        private float tileSize = 30;
        public float score = 0;
        public float way = 0;
        private Vector2 startPosition;
        public Vector2 kek;
     //   public Rigidbody2D rbd2d;

        void Start()
        {
          startPosition = transform.position;
         //rbd2d = GetComponent<Rigidbody2D>();
         //rbd2d.velocity = new Vector2 (scrollSpeed, 0);
        }

    void Update()
    {
      score++;
      way = (scrollSpeed*Time.deltaTime);
      score = (score + (way % 10));
      float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
      transform.position = startPosition + Vector2.down * newPosition; 
    } 
    void OnGUI()
    {
	    GUI.Box (new Rect (0, 0, Screen.width, Screen.height*0.05f), "Distance: " + Mathf.RoundToInt(score/10));
    }

}
