using UnityEngine;
using System.Collections;

public class CompleteStageCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
			Debug.Log("stage complete");
			GameData.current.currentLevel.Complete();

		}	
	}
}
