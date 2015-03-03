using UnityEngine;
using System.Collections;

public class NPCbehavior : MonoBehaviour {

	private bool playerIsNear = false;
	public GameObject speechBubble;

	void Start(){
		speechBubble.SetActive(false);
	}

	void OnMouseDown(){
		if (playerIsNear){
			Debug.Log("hello");
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			speechBubble.SetActive(true);
			playerIsNear = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			speechBubble.SetActive(false);
			playerIsNear = false;
		}
	}
}
