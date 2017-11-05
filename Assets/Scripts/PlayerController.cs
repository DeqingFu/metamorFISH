using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float speed_blink;

	private Rigidbody2D rb2d;
	private int face_flag = 0;
	public GameObject bubble;
	public float bubble_bias_x;
	public float bubble_bias_y;
	//public static spawn spawner = new spawn();

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
		//spawner.StartSpawning ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Muse.GetAccLeftRight()/100.0f;
		//Debug.Log (moveHorizontal);
		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);
		rb2d.AddForce (movement * speed);
		//Debug.Log (Muse.blinks);
		if (Muse.blinks == 1) {
			Vector2 vertForce = new Vector2 (0.0f, speed_blink);
			rb2d.AddForce (vertForce * speed);
		}

		if (moveHorizontal < 0.0f && face_flag == 1) {
			transform.localScale =new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			face_flag = 0;
		}
		if (moveHorizontal > 0.0f && face_flag == 0) {
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			face_flag = 1;
		}

		if (Muse.jaw == 1) {
			GenerateBubble ();
		}
	}
		

	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag =="Left")
		{

			transform.localScale =new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			face_flag = face_flag == 0? 1 : 0;

		}

		if (coll.gameObject.tag =="Right")
		{

			transform.localScale =new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			face_flag = face_flag == 0? 1 : 0;

		}

	}

	void GenerateBubble(){
		float posX = rb2d.position.x;
		float posY = rb2d.position.y;
		Instantiate (bubble, new Vector3 (posX + (face_flag == 0 ? -1 : 1) * bubble_bias_x, posY + bubble_bias_y, 0f), Quaternion.identity);
	}
}
