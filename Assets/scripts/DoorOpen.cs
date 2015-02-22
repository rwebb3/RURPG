using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
	public Sprite openedDoor;
	public Sprite closedDoor;

	private bool isOpen = false;
	private float timeToWait = 0f;

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
			isOpen = false;
			//set an amount of time to wait before closing the door (prevents "stutter")
			timeToWait = 0.5f;

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// FixedUpdate is called once per tick
	void FixedUpdate () {
		if (isOpen)
			this.GetComponent<SpriteRenderer>().sprite = openedDoor;
		else{
			//update the timer
			timeToWait -= Time.deltaTime;
			if (timeToWait <= 0f){
				this.GetComponent<SpriteRenderer>().sprite = closedDoor;
			}
		}
	}
}
