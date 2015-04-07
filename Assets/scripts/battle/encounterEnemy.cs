using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class encounterEnemy : MonoBehaviour {
	public GameObject mainObject;
	
	private List<EntityStats> theEnemies;
	private GameObject bm;

	void OnTriggerEnter2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy")){
			//Debug.Log("hit enemy");
			Application.LoadLevelAdditive("DefaultBattle");
			theEnemies = other.gameObject.GetComponent<DefineEncounter>().GetEnemyList();
			Debug.Log ("encounter: " + theEnemies.Count);
			Destroy(other.transform.parent.gameObject);
		}
	}
	
	void OnDisable(){
		bm = GameObject.FindGameObjectWithTag("BattleManager");
		//bm.GetComponent<BattleSystem>().setUpBattle(theEnemies);
	}
}
