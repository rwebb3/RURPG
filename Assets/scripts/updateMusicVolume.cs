using UnityEngine;
using System.Collections;

public class updateMusicVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.audio.volume = GlobalVars.musicVolume;
	}
}
