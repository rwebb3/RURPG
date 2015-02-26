using UnityEngine;
using System.Collections;

public class hideCanvas : MonoBehaviour {

	public GameObject menu;
	public bool isShowing = false;
	
	void Start () {
		//keep canvas hidden until collision w/ door
		menu.SetActive (isShowing);
	}

	void Update () {
		menu.SetActive (isShowing);
	}

}
