using UnityEngine;
using System.Collections;

[System.Serializable]
public class Level{
	public string name;
	public bool isComplete;

	public Level(){
		this.name = "";
		this.isComplete = false;
	}

	public void Complete(){
		this.isComplete = true;
	}

}
