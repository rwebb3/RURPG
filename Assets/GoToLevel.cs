using UnityEngine;
using System.Collections;

public class GoToLevel : MonoBehaviour {
	public string LevelName;

	void OnTriggerEnter2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player")){
			//set list of unobtained items to emtpy list
			GameData.current.currentLevel.unObtainedItems = new Inventory();
			AutoFade.LoadLevel("MuseRooftop" ,2,1,Color.black);
			GameObject[] itemsStillInMap = GameObject.FindGameObjectsWithTag("Item");
			//for each item still in map, add item to unObtainedItems
			foreach (GameObject anItem in itemsStillInMap){
				GameData.current.currentLevel.unObtainedItems.AddItem(anItem.GetComponent<ItemBehavior>().thisItem);
			}
		}
	}
}
