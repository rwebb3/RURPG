using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour {

	public List<EntityStats> encounterEnemyStats; //stats from DefineEncounter
	private List<EntityStats> savedPlayerStats; //stats from GameData
	private GameObject[] playerObjects; //player objects in scene
	private GameObject[] enemyObjects; //enemy objects in scene

	private List<GameObject> allBattleEntities; //battle entities to be ordered by speed
	private int entityTurn; //which entities turn it currently is.

	// Use this for initialization
	void Start () {
		//a list of characters for testing
		List<EntityStats> players = new List<EntityStats>();
		players.Add(new EntityStats(5, 3, 10, 10, 10, 10, 10, "Howard", "Sprites/RED"));
		players.Add(new EntityStats(5, 3, 10, 10, 10, 10, 10, "Steve", "Sprites/RED"));

		//give all player entitiy objects their previously saved stats.
		savedPlayerStats = players; //GameData.current.players;
		playerObjects = GameObject.FindGameObjectsWithTag("BattlePlayer");
		for (int i = 0; i < playerObjects.Length; i++){
			if (i<savedPlayerStats.Count){
				playerObjects[i].GetComponent<BattleEntity>().setupEntity( savedPlayerStats[i].hp,
				                                                           savedPlayerStats[i].sp,
				                                                           savedPlayerStats[i].base_atk,
				                                                           savedPlayerStats[i].base_def,
				                                                           savedPlayerStats[i].base_spd,
				                                                           savedPlayerStats[i].maxHP,
				                                                           savedPlayerStats[i].maxSP,
				                                                           savedPlayerStats[i].entityName,
				                                                           savedPlayerStats[i].sprite);
				                                                        
				playerObjects[i].GetComponent<SpriteRenderer>().sprite = playerObjects[i].GetComponent<BattleEntity>().getSprite(); 
				
			}
		}
		//a list of enemies for testing
		List<EntityStats> enemies = new List<EntityStats>();
		enemies.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/RED"));

		//give all battle enemies their stats from the encounter stats
		encounterEnemyStats = enemies;
		enemyObjects = GameObject.FindGameObjectsWithTag("BattleEnemy");
		for (int i = 0; i < enemyObjects.Length; i++)
		{
			if (i<encounterEnemyStats.Count){
				enemyObjects[i].GetComponent<BattleEntity>().setupEntity( encounterEnemyStats[i].hp,
				                                                          encounterEnemyStats[i].sp,
				                                                          encounterEnemyStats[i].base_atk,
				                                                          encounterEnemyStats[i].base_def,
				                                                          encounterEnemyStats[i].base_spd,
				                                                          encounterEnemyStats[i].maxHP,
				                                                          encounterEnemyStats[i].maxSP,
				                                                          encounterEnemyStats[i].entityName,
				                                                          encounterEnemyStats[i].sprite);

				enemyObjects[i].GetComponent<SpriteRenderer>().sprite = enemyObjects[i].GetComponent<BattleEntity>().getSprite();
			}
			else{
				enemyObjects[i].SetActive(false);
			}
		}

		//find all the battle entities in the scene and add them to the list
		allBattleEntities = new List<GameObject>();
		foreach (GameObject aPlayer in GameObject.FindGameObjectsWithTag("BattlePlayer")){
			allBattleEntities.Add(aPlayer);
		}
		foreach (GameObject anEnemy in GameObject.FindGameObjectsWithTag("BattleEnemy")){
			allBattleEntities.Add(anEnemy);
		}
		//sort the battle entities by speed for turn order
		allBattleEntities.Sort((x, y) => y.GetComponent<BattleEntity>().getBase_spd().CompareTo(x.GetComponent<BattleEntity>().getBase_spd()));
		
		entityTurn = 0;
		allBattleEntities[entityTurn].SendMessage("takeTurn");
		
	}
	
	
	// Update is called once per frame
	void Update () {
		

	}
}
