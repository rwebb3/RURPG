using UnityEngine;
using System.Collections;

public class ExitStage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		//if the thing that entered was the player, change the sprite to the opened door.
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			//set list of unobtained items to emtpy list
			GameData.current.currentLevel.unObtainedItems = new Inventory();
			AutoFade.LoadLevel("map" ,2,1,Color.black);
			GameObject[] itemsStillInMap = GameObject.FindGameObjectsWithTag("Item");
			//for each item still in map, add item to unObtainedItems
			foreach (GameObject anItem in itemsStillInMap){
				GameData.current.currentLevel.unObtainedItems.AddItem(anItem.GetComponent<ItemBehavior>().thisItem);
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
