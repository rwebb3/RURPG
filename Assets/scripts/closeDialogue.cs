using UnityEngine;
using System.Collections;

public class closeDialogue : MonoBehaviour {

	public GameObject thePanelToClose;
	private bool isShowing = true;

	public void Start(){
		//thePanelToClose = this.transform.parent.gameObject;
	}

	//Button should close Help Text
	public void OKbutton() {
		isShowing = false;
		thePanelToClose.SetActive(isShowing);
		Time.timeScale = 1;
	}

}
