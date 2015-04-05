using UnityEngine;
using System.Collections;

public class FlashTest : MonoBehaviour {

	private bool fadeIn;
	private float fadeSpeed = 1f;
	private float fadeTime = 1f;
	private float blueness = 1f;

	// Update is called once per frame
	void Update () {
		if (blueness >= 1f)
			fadeIn = false;
		else if(blueness <= 0f)
			fadeIn = true;
		if (fadeIn){
			//this.transform.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.Lerp(Color.white, Color.yellow, Time.time%1));
			blueness += .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,blueness,1f);
		}
		else{
			//this.transform.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.Lerp(Color.yellow, Color.white, Time.time%1));
			blueness -= .01f;
			this.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,blueness,1f);
		}
	}
}
