using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class encounterEnemy : MonoBehaviour {
	public GameObject mainObject;
	
	private List<EntityStats> theEnemies;
	private GameObject bm;
	private bool encounteredEnemy = false;

	void OnTriggerEnter2D(Collider2D other){
		if (LayerMask.LayerToName(other.gameObject.layer).Equals("Enemy")){
			encounteredEnemy = true;
			//Debug.Log("hit enemy");
			Application.LoadLevelAdditive("DefaultBattle");
			theEnemies = other.gameObject.GetComponent<DefineEncounter>().GetEnemyList();
			Debug.Log ("encounter: " + theEnemies.Count);
			Destroy(other.transform.parent.gameObject);
		}
	}
	
	void OnDisable(){
	  if (encounteredEnemy){
		bm = GameObject.FindGameObjectWithTag("BattleManager");
		bm.GetComponent<BattleSystem>().setupBattle(theEnemies);
		encounteredEnemy = false;
	  }
	}
}
