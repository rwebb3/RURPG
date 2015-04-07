using UnityEngine;
using System.Collections;

public class VisualEffects : MonoBehaviour {

	//for yellow flashing
	private bool hiliteFadeIn;
	private float blueness = 1f;
	private bool hilited = false;

	void hilite(){
		if (!hilited){
			hilited = true;
		}
	}
	void nohilite(){
		if(hilited){
			hilited = false;
		}
	}

	// Update is called once per frame
	void Update () {
	  if(hilited){
		if (blueness >= 1f)
			hiliteFadeIn = false;
		else if(blueness <= 0f)
			hiliteFadeIn = true;
		if (hiliteFadeIn){
			blueness += .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,blueness,1f);
		}
		else{
			blueness -= .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,blueness,1f);
		}
	 }
   }
}
