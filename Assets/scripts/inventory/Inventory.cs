using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory{
	public List<Item> items; 

	public Inventory(){
		this.items = new List<Item>();
	}

	public void AddItem(Item theItem){
		items.Add(theItem);
	}

	public bool Contains(Item anItem){
		bool foundStatus = false;
		foreach(Item itemToCheck in items){
			if (anItem.Equals(itemToCheck))
				foundStatus = true;
		}
		return foundStatus;
	}

}
