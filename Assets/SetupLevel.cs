using UnityEngine;
using System.Collections;

public class SetupLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameData.current != null && GameData.current.currentLevel.isComplete){
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] allItems = GameObject.FindGameObjectsWithTag("Item");
			//for each item still in map, add item to unObtainedItems
			foreach (GameObject anEnemy in enemies){
				GameObject.Destroy(anEnemy);
			}
			foreach (GameObject anItemInLevel in allItems){
				if (!GameData.current.currentLevel.unObtainedItems.Contains(anItemInLevel.GetComponent<ItemBehavior>().thisItem)){
					GameObject.Destroy(anItemInLevel);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
