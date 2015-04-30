﻿using UnityEngine;
using System.Collections;

public class ShowOtherPanel : MonoBehaviour {

	public GameObject thePanelToHide;
	public GameObject thePanelToShow;
	
	public void Start(){
		//thePanelToClose = this.transform.parent.gameObject;
	}
	
	//Button should close Help Text
	public void UseButton() {
	  if(thePanelToHide != null){
		thePanelToHide.SetActive(false);
	  }
	  if(thePanelToShow != null){
		thePanelToShow.SetActive(true);
	  }
	}
}
