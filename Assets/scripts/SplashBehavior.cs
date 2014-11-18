using UnityEngine;
using System.Collections;

public class SplashBehavior : MonoBehaviour {

	public GameObject currentPanelObject;
	public GameObject nextPanelObject;
	float timer = 6.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 1){
			NGUITools.SetActive(nextPanelObject, true);
			NGUITools.SetActive(currentPanelObject, false);
			}
		timer -= Time.deltaTime;
	}
}
