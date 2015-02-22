using UnityEngine;
using System.Collections;

public class SetLayer : MonoBehaviour {

	//if the trigger is within a collider
	void OnTriggerStay2D(Collider2D other){
		string theLayerName = LayerMask.LayerToName(other.gameObject.layer);
		Renderer objectRenderer = this.gameObject.transform.parent.renderer;
		//check that it is not the Default layer
		if (!theLayerName.Equals("Default") && !theLayerName.Equals("Player") && !theLayerName.Equals("Enemy")){

			//set the player's sprite to be on the same layer as the collided object
			objectRenderer.sortingLayerName = theLayerName;
		}
	}

	//when the trigger leaves the collider
	void OnTriggerExit2D(Collider2D other){
		//set the player sprite to be on the player layer
		this.gameObject.transform.parent.renderer.sortingLayerName = LayerMask.LayerToName(this.gameObject.layer);
	}
	
}
