using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour {
	public GameObject gameOverPanel;
	public GameObject victoryPanel;

	[HideInInspector]
	public List<EntityStats> encounterEnemyStats; //stats from DefineEncounter
	private List<EntityStats> savedPlayerStats; //stats from GameData
	private GameObject[] playerObjects; //player objects in scene
	private GameObject[] enemyObjects; //enemy objects in scene
	private GameObject[] mainObjects; //objects from the main scene

	private List<GameObject> allBattleEntities; //battle entities to be ordered by speed
	private int entityTurn; //which entities turn it currently is.

	private float waitTimer = -1;

	void Start(){
		mainObjects = GameObject.FindGameObjectsWithTag("MainScene");
		foreach (GameObject anObject in mainObjects){
			anObject.SetActive(false);
		}
	}

	// Use this for initialization
	public void setupBattle (List<EntityStats> theEnemies) {
		Debug.Log("setupBattle");
		
		//a list of characters for testing
		/*List<EntityStats> players = new List<EntityStats>();
		players.Add(new EntityStats(5, 3, 10, 3, 10, 10, 10, "Steve", "Sprites/mustrumridcully_back"));
		players.Add(new EntityStats(5, 3, 10, 4, 10, 10, 10, "Howard", "Sprites/RED_back"));*/
		

		//give all player entitiy objects their previously saved stats.
		//savedPlayerStats = players; 
		savedPlayerStats = GameData.current.players;
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
		/*List<EntityStats> enemies = new List<EntityStats>();
		enemies.Add(new EntityStats(3, 5, 6, 4, 4, 6, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(4, 2, 4, 4, 4, 8, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(4, 2, 8, 4, 4, 4, 4, "Robot", "Sprites/silverrobotontracks_battle"));
		enemies.Add(new EntityStats(4, 2, 10, 4, 4, 4, 4, "Robot", "Sprites/silverrobotontracks_battle"));*/

		//give all battle enemies their stats from the encounter stats
		//encounterEnemyStats = enemies;
		encounterEnemyStats = theEnemies;
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

	IEnumerator gameOver(){
		this.gameOverPanel.SetActive(true);
		float waitTime = 4f;
		while (waitTime > 0f){
			waitTime -= Time.deltaTime;
			yield return null;
		}
		if (waitTime < 0f){
			Application.LoadLevel("MainMenu");
			yield return null;
		}
		
	}

	IEnumerator victory(){
		this.victoryPanel.SetActive(true);
		float waitTime = 3f;
		while (waitTime > 0f){
			waitTime -= Time.deltaTime;
			yield return null;
		}
		if (waitTime < 0f){
			foreach (GameObject aMainObject in mainObjects){
				aMainObject.SetActive(true);
				yield return null;
			}
			foreach (GameObject anObject in GameObject.FindGameObjectsWithTag("BattleScene")){
				Debug.Log (anObject);
				Destroy(anObject);
				yield return null;
			}
			Destroy(GameObject.FindGameObjectWithTag("BattleWrapper"));
		}
	}
	
	public void nextTurn(){
		//check if all players have died.
		bool allPlayersDead = true;
		//check if all enemies have died.
		bool allEnemiesDead = true;
		foreach (GameObject aBattleObject in allBattleEntities){
			if (aBattleObject.tag.Equals("BattlePlayer") && !aBattleObject.GetComponent<BattleEntity>().isDead()){
				allPlayersDead = false;
			}
			else if (aBattleObject.tag.Equals("BattleEnemy") && !aBattleObject.GetComponent<BattleEntity>().isDead()){
				allEnemiesDead = false;
			}
		}


		foreach (GameObject anEnemy in GameObject.FindGameObjectsWithTag("BattleEnemy")){
			if (!anEnemy.GetComponent<BattleEntity>().isDead()){
				allEnemiesDead = false;
			}
		}

		if(allPlayersDead){
			StartCoroutine("gameOver");
		}

		if(allEnemiesDead){
			StartCoroutine("victory");
		}

		if(!allPlayersDead && !allEnemiesDead){
			entityTurn++; 
			entityTurn %= allBattleEntities.Count;
			//if the entity is dead, go to the next entity
			if (allBattleEntities[entityTurn].GetComponent<BattleEntity>().isDead()){
				nextTurn ();
			}
			else{
				allBattleEntities[entityTurn].SendMessage("takeTurn");
			}
		}
	}
}
