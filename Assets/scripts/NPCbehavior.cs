using UnityEngine;
using System.Collections;

public class NPCbehavior : MonoBehaviour {

	private bool playerIsNear = false;
	public GameObject speechBubble;
	public GameObject speechPanel;

	void Start(){
		speechBubble.SetActive(false);
	}

	void OnMouseDown(){
		if (playerIsNear){
			speechPanel.SetActive(true);
			//Debug.Log("hello");
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
	
	void Update(){
		if(Time.timeScale.Equals(0)){
			this.GetComponent<Collider2D>().enabled = false;
		}
		else{
			this.GetComponent<Collider2D>().enabled = true;
		}
	}
		
}
