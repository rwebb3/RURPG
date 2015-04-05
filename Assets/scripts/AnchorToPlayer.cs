using UnityEngine;
using System.Collections;

public class AnchorToPlayer : MonoBehaviour {
	//this is your object that you want to have the UI element hovering over
	public GameObject worldObject;
	RectTransform rt; 
	
	// Use this for initialization
	void Start () {
		rt = (RectTransform)this.transform;
		Vector2 pos = gameObject.transform.position; // get the game object position
		Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos); //convert game object position to VievportPoint
		// set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
		rt.anchorMin = viewportPoint;
		rt.anchorMax = viewportPoint;
	}
}
