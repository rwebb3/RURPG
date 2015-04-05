using UnityEngine;
using System.Collections;

public class LoadBattleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	Application.LoadLevelAdditive("battle");
	this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
