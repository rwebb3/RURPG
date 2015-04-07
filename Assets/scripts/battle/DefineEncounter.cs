using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DefineEncounter : MonoBehaviour {

	private List<EntityStats> enemyList;
	void Start(){
		enemyList = new List<EntityStats>();
		//EnemyBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName) 
		enemyList.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemyList.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemyList.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemyList.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/RED"));
	}
		
		

	// Use this for initialization
	public List<EntityStats> GetEnemyList(){
		return enemyList;
	}
}
