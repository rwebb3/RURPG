using UnityEngine;
using System.Collections;

public class StartNewGame : MonoBehaviour {
	//public int FileNumber;
	void OnSubmit(){
		//SaveLoad.FilNum = FileNumber;
		GameData.current = new GameData();
		GameData.current.name = UIInput.current.text;
		SaveLoad.Save();
		//Debug.Log(GameData.current.name);
		GameData.current.setCurrentLevel("TutorialLevel");
		Application.LoadLevel("tutorialLevel");

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
