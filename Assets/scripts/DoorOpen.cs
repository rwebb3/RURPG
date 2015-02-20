using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
	public Sprite openedDoor;
	public Sprite closedDoor;

	private bool isOpen = false;

	void OnTriggerStay2D(Collider2D other){
		//if the thing that entered was the player, change the sprite to the opened door.
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			//this.GetComponent<SpriteRenderer>().sprite = openedDoor;
			isOpen = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		//if the thing that left was the player, change the sprite to the closed door
		//players are very polite
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			//this.GetComponent<SpriteRenderer>().sprite = closedDoor;
			isOpen = false;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen)
			this.GetComponent<SpriteRenderer>().sprite = openedDoor;
		else
			this.GetComponent<SpriteRenderer>().sprite = closedDoor;
	}
}
