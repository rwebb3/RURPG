using UnityEngine;
using System.Collections;

public class SetLayer : MonoBehaviour {
	//if the trigger is within a collider
	void OnTriggerStay2D(Collider2D other){
		//Debug.Log("hit something");
		string theLayerName = LayerMask.LayerToName(other.gameObject.layer);
		Renderer playerRenderer = this.gameObject.transform.parent.renderer;

		//check that it is not the Default layer
		if (!theLayerName.Equals("Default")){

			//set the player's sprite to be on the same layer as the collided object
			playerRenderer.sortingLayerName = theLayerName;
		}
		else
			playerRenderer.sortingLayerName = "Player";
	}

	//when the trigger leaves the collider
	void OnTriggerExit2D(Collider2D other){
		//set the player sprite to be on the player layer
		this.gameObject.transform.parent.renderer.sortingLayerName = "Player";
	}
	
}
