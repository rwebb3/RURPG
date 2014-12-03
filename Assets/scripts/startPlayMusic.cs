using UnityEngine;
using System.Collections;

public class startPlayMusic : MonoBehaviour {

	public UIPanel mainPanel;
	bool playing = false;
	
	// Update is called once per frame
	void Update () {
		if (mainPanel.alpha > 0.0f && !playing){
			gameObject.audio.Play();
			playing = true;
		}
	}
}
