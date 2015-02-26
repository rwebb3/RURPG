using UnityEngine;
using System.Collections;

public class closeDialogue : MonoBehaviour {

	public GameObject menu;
	private bool isShowing = true;

	//Button should close Help Text
	public void OKbutton() {
		isShowing = false;
		menu.SetActive (isShowing);
		Time.timeScale = 1;
	}

}
