using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Sprite openedDoor;
	public Sprite closedDoor;
	public bool isLocked = false; //is the door locked?
	public GameObject aKeyObject; //the in world key object

	private float timeToWait = 0f; //used on the timer to prevent door flicker
	private bool isOpen = false; //checks if the door is open
	private Item keyToFitLock; //the logical key that will fit the lock
	private BoxCollider2D doorCollider; //the doors collider (starts as a trigger)
	private ItemBehavior theKey;

	void OnTriggerStay2D(Collider2D other){
		//if the thing that entered was the player and the player has they key for this door
		//change the sprite to the opened door.
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			if (isLocked && GlobalVars.currentInventory.Contains(keyToFitLock) || !isLocked){
				isOpen = true;
			}
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
		//grab the door's collider
		doorCollider = this.gameObject.GetComponent<BoxCollider2D>();
		// if the door is locked make it impassable
		if (isLocked){
			doorCollider.isTrigger = false;
		}
		if (aKeyObject != null){
			//get the item behavior data off the key object
			theKey = aKeyObject.GetComponent<ItemBehavior>();
		}
		//if the key has real data
		if (theKey != null){
			//make a key for comparison
			keyToFitLock = theKey.thisItem;
		}
	}
	
	// FixedUpdate is called once per tick
	void FixedUpdate () {
		if (isOpen){
			doorCollider.isTrigger = true;
			this.GetComponent<SpriteRenderer>().sprite = openedDoor;
		}
		else{
			//update the timer
			timeToWait -= Time.deltaTime;
			if (timeToWait <= 0f){
				this.GetComponent<SpriteRenderer>().sprite = closedDoor;
			}
		}
	}
}
