using UnityEngine;
using System.Collections;

public class EndBattle : MonoBehaviour {
	private GameObject mainScene;
	
	void EndButton(){		
		foreach (GameObject anObject in GameObject.FindGameObjectsWithTag("BattleScene")){
			Debug.Log (anObject);
			Destroy(anObject);
			mainScene.SetActive(true);
		}
	}
	
	public void Start(){
		//capture and secure the Main package
		mainScene = GameObject.FindGameObjectWithTag("MainScene");
		mainScene.SetActive(false);
	
	}
		
		
}
