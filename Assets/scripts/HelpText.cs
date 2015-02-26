using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		if (LayerMask.LayerToName (other.gameObject.layer).Equals ("Player")) {
			this.GetComponent<hideCanvas> ().isShowing = true;
			this.collider2D.enabled = false;
			Time.timeScale = 0;
		}
	}

}
