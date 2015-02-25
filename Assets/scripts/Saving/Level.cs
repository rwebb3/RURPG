using UnityEngine;
using System.Collections;

[System.Serializable]
public class Level{
	public string name;
	public bool isComplete;
	public Inventory unObtainedItems;

	public Level(){
		this.name = "";
		this.isComplete = false;
		this.unObtainedItems = new Inventory();
	}

	public void Complete(){
		this.isComplete = true;
	}

}
