using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePopUp : MonoBehaviour {

	public void onRestartClick() {
		Destroy(this.gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void onMenuClick() {
		Destroy(this.gameObject);
		SceneManager.LoadScene("MainMenu");
	}

}
