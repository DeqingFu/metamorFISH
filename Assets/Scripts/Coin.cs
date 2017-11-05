using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player" ||coll.tag == "Bottom"  ) {
			spawn.counter -= 1;
			Destroy (this.gameObject);

		}
	}
}
