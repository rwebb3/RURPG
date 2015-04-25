using UnityEngine;
using System.Collections;

public class VisualEffects : MonoBehaviour {

	//for yellow flashing
	private bool hiliteFadeIn;
	private float blueness = 1f;
	private float greenness = 1f;
	private float redness = 1f;
	private bool hilited = false;
	private bool redhilited = false;

	void hilite(){
		if (!hilited){
			redness = 1f;
			greenness = 1f;
			blueness = 1f;
			hilited = true;
			redhilited = false;
		}
	}
	void nohilite(){
		if(hilited || redhilited){
			hilited = false;
			redhilited = false;
		}
	}

	void redhilite(){
		if(!redhilited){
			redness = 1f;
			greenness = 1f;
			blueness = 1f;
			hilited = false;
			redhilited = true;
		}
	}
	/*
	void glowGreen(){
		if(!glowingGreen){
			glowingGreen = true;
		}
	}

	void noGlowGreen(){
		if(glowingGreen){
			glowingGreen = false;
		}
	}*/


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
	  else if(redhilited){
		if (redness >= 1f)
			hiliteFadeIn = false;
		else if(redness <= 0f)
			hiliteFadeIn = true;
		if (hiliteFadeIn){
			redness += .01f;
				Debug.Log(redness);
			greenness -= .01f;
			blueness -= .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f);
		}
		else{
			redness -= .01f;
			greenness += .01f;
			blueness += .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		}
	  }
	 else{
	  	this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
	 }
   }
}
