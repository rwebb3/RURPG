using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {

	private bool playerIsNear = false;
	private Item thisItem;

	public string name;
	public string type;

	void OnMouseDown(){
		if (playerIsNear){
			GlobalVars.currentInventory.AddItem(thisItem);
			Destroy(this.gameObject);
			Debug.Log (GlobalVars.currentInventory.items[0].name);
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
	void Start () {
		thisItem = new Item(name, type);
	}
}
