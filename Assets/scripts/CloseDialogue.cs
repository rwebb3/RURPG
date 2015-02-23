using UnityEngine;
using System.Collections;

public class CloseDialogue : MonoBehaviour {

	public GameObject menu;
	private bool isShowing = true;

	// Use this for initialization
	public void Okay () {
		isShowing = false;
		menu.SetActive (isShowing);
	}

}
