using UnityEngine;
using System.Collections;

public class NewPause : MonoBehaviour {

	public GameObject pausePanel;

	// Update is called once per tick
	void FixedUpdate() {
		if (Input.GetKey(KeyCode.Escape)){
			pausePanel.SetActive(true);
		}			
	}
}
