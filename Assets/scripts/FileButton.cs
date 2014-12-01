using UnityEngine;
using System.Collections;

public class FileButton : MonoBehaviour {
	
	public GameObject promptPanelObject;
	public GameObject filePanel;

	public int FileNumber;

	public bool dataExists = false;

	void Start(){
		if (!(SaveLoad.savedGames[FileNumber] == null)){
			dataExists = true;
			GameData thisData = SaveLoad.savedGames[FileNumber];
			GetComponentInChildren<UILabel>().text = thisData.name; 
			Debug.Log (thisData.name);
		}
	}
	void OnClick() {
		if (!dataExists){
			SaveLoad.FilNum = FileNumber;
			NGUITools.SetActive(promptPanelObject, true);
			//promptPanelObject.GetComponentInChildren<StartNewGame>().FileNumber = this.FileNumber; 
			ActivateAllExcept(false, "FilePrompt");
		}
		else{
			Debug.Log("I'm here");
			GameData.current = SaveLoad.savedGames[FileNumber];
			Application.LoadLevel("map");
		}
	}

	void ActivateAllExcept(bool activate, string _except)
	{
		// this will get you all the colliders of all widgets under your panel - recursively
		Collider[] colliders = filePanel.GetComponentsInChildren<Collider>();
		foreach (Collider col in colliders)
			if (col.gameObject.tag != _except) // for this to work, names should be unique. I just used the name as an example, use whatever unique identifier you want...
				col.enabled = activate;
	}
}
