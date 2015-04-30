using UnityEngine;
using System.Collections;

public class PauseAfterSeconds : MonoBehaviour {

	public float waitToPause;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (waitToPause > 0){
			waitToPause -= Time.deltaTime;
		}
		if (waitToPause <= 0){
			Time.timeScale = 0;
		}
			
	}
}
