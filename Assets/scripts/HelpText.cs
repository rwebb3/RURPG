using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	public GameObject thePanelToOpen;
	// Use this for initialization
	void Start(){
		if (GameData.current != null && GameData.current.currentLevel.isComplete){
			this.GetComponent<Collider2D>().enabled = false;
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (LayerMask.LayerToName (other.gameObject.layer).Equals ("Player")) {
			//this.GetComponent<hideCanvas>().isShowing = true;
			thePanelToOpen.SetActive(true);
			this.GetComponent<Collider2D>().enabled = false;
		}
	}

}
