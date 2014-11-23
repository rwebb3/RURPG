using UnityEngine;
using System.Collections;

public class updateMusicVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.audio.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.audio.volume = GlobalVars.musicVolume;
	}
}
