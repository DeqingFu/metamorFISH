using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_to_menu : MonoBehaviour {
	public void back(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
	}
}
