using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour {
	public void ChangeScene(int scene_number) { 
		if (scene_number == 1) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("OneFish");
		} else if (scene_number == 2) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("TwoFish");
		} else if (scene_number == 3) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("NilFish");
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MoreFish");
		}
	}
}
