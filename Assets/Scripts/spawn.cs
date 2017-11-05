using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
	
	//public Transform[] spawnPoints;
	public float spawnTime = 1.5f;
	public GameObject pickup;
	public int maxFood;
	public static int counter;


	void Start()
	{
		//Debug.Log ("nooo");
		InvokeRepeating ("SpawnPickup", spawnTime, spawnTime); 
		counter = 0;
	}

	void Update()
	{
		
		
	}
	void SpawnPickup() {
		if (counter < maxFood) {
			float posX = Random.Range (-40, 40);
			float posY = Random.Range (21, 22);
			Instantiate (pickup, new Vector3 (posX, posY, 0f), Quaternion.identity);
			counter += 1;
		}
	}
		
}
