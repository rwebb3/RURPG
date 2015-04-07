using UnityEngine;
using System.Collections;

public class BattleButtonsBehaviors : MonoBehaviour {

	public GameObject GameManager;
	private BattleSystem currentBattleSystem;

	void Attack(){
		//BattleSystem.buttonSelected = "attack";
		//currentBattleSystem.setAction(new AttackBattleAction(
	}

	// Use this for initialization
	void Start () {
			currentBattleSystem = GameManager.GetComponent<BattleSystem>();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
