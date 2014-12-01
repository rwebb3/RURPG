using UnityEngine;
using System.Collections;

public class CompleteStage : MonoBehaviour {
	public string stageName;
	public UIButton thisButton;

	void OnClick(){
	foreach (Level l in GameData.current.levels){
			if (l.name.Equals(stageName)){
				l.Complete();
				thisButton.isEnabled = false;
			}
		}
	}

	// Use this for initialization
	void Start () {
		foreach (Level l in GameData.current.levels){
			if (l.isComplete){
				Debug.Log("it's complete");
				thisButton.isEnabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
