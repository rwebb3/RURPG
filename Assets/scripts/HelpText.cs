using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	public GameObject thePanelToOpen;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		if (LayerMask.LayerToName (other.gameObject.layer).Equals ("Player")) {
			//this.GetComponent<hideCanvas>().isShowing = true;
			thePanelToOpen.SetActive(true);
			this.collider2D.enabled = false;
			Time.timeScale = 0;
		}
	}

}
