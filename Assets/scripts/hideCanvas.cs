using UnityEngine;
using System.Collections;

public class hideCanvas : MonoBehaviour {

	public GameObject panel;
	public bool isShowing = false;
	
	void Start () {
		//keep panel hidden until collision w/ door
		panel.SetActive (isShowing);
	}

	void Update () {
		panel.SetActive (isShowing);
	}

}
