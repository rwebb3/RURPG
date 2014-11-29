using UnityEngine;
using System.Collections;

public class startMusicPlay : MonoBehaviour {
	public UIPanel mainPanel;
	bool playing = false;
	// Update is called once per frame
	void Update () {
		if (mainPanel.alpha > 0.0f && !playing){
			audio.Play();
			playing = true;
		}
	}
}
