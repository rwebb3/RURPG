using UnityEngine;
using System.Collections;

public class closeDialogue : MonoBehaviour {

	public GameObject menu;
	public GameObject menu2;
	private bool isShowing = true;

	//Button should close Help Text
	public void OKbutton() {
		isShowing = false;
		menu.SetActive (isShowing);
		menu2.SetActive (isShowing);
		Time.timeScale = 1;
	}

}
