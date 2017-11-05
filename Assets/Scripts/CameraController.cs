using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;

	//private Transform tr;


	// Use this for initialization
	void Start () {
		//tr = player.transform;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = player.transform.position;
		temp.z = transform.position.z;
		transform.position = temp;
		
	}
}
