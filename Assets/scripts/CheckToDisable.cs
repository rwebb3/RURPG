using UnityEngine;
using System.Collections;

public class CheckToDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameData.current != null && GameData.current.currentLevel.isComplete){
			this.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
