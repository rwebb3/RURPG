using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DefineEncounter : MonoBehaviour {

	private List<EnemyBattleEntity> enemyList;
	void Start(){
		enemyList = new List<EnemyBattleEntity>();
		//EnemyBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName) 
		/*
		enemyList.Add(new EnemyBattleEntity(3, 2, 2, 4, 4, 5, 4, "Robot"));
		enemyList.Add(new EnemyBattleEntity(2, 2, 2, 4, 4, 5, 4, "Robot"));
		enemyList.Add(new EnemyBattleEntity(4, 2, 2, 4, 4, 5, 4, "Robot"));
		enemyList.Add(new EnemyBattleEntity(5, 2, 2, 4, 4, 5, 4, "Robot"));
		*/
	}
		
		

	// Use this for initialization
	public List<EnemyBattleEntity> GetEnemyList(){
		return enemyList;
	}
}
