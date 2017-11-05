using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroController : MonoBehaviour {
	public GameObject target;

	private Vector3 offset = new Vector3(1,1,1); 
	private Vector3 previous= new Vector3(0.0f, 0.0f, 0.0f);
	private int face_flag = 0;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
		Vector3 velocity = (transform.position - previous) / Time.deltaTime;
		Debug.Log (velocity);
		if (velocity.x > 0 && face_flag == 0 || velocity.x < 0 && face_flag == 1)
		{
			
			transform.localScale =new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			face_flag = face_flag == 0? 1 : 0;
		}
		previous = transform.position;

	}
}
