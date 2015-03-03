using UnityEngine;
using System.Collections;

public class NPCbehavior : MonoBehaviour {

	private bool playerIsNear = false;


	void OnMouseDown(){
		if (playerIsNear){
			Debug.Log("hello");
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			playerIsNear = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			playerIsNear = false;
		}
	}
}
