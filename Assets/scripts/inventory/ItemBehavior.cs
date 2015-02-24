using UnityEngine;
using System.Collections;

public class ItemBehavior: MonoBehaviour {

	private bool playerIsNear = false;

	[HideInInspector]
	public Item thisItem;

	public string itemName;
	public string itemId;
	public string itemType;

	void OnMouseDown(){
		if (playerIsNear){
			GlobalVars.currentInventory.AddItem(thisItem);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			playerIsNear = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			this.transform.localEulerAngles = new Vector3(0,0,-45);
			playerIsNear = false;
		}
	}
	// Use this for initialization
	void Awake () {
		thisItem = new Item(itemName, itemId, itemType);
	}
}
