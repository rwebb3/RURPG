using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour {
		public GameObject alertText;
		[HideInInspector]
		public List<EnemyBattleEntity> enemies;
		private List<PlayerBattleEntity> playerCharacters;
		private bool battleOver = false;
		private GameObject currentPlayerActions;
		private GameObject[] playerObjects;
		private GameObject[] enemyObjects;
		public GameObject player1Actions;
		public GameObject player2Actions;
		//public string buttonSelected;

		void Start(){
			alertText.SetActive(false);
			alertText.SetActive(true);
			alertText.GetComponent<Text>().text = "test";


			///testing list
			List<EnemyBattleEntity> enemyList = new List<EnemyBattleEntity>();
			//EnemyBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName) 
			enemyList.Add(new EnemyBattleEntity(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
			enemyList.Add(new EnemyBattleEntity(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
			enemyList.Add(new EnemyBattleEntity(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/silverrobotontracks_battle"));
			enemyList.Add(new EnemyBattleEntity(3, 2, 2, 4, 4, 5, 4, "Robot", "Sprites/RED"));
			setUpBattle(enemyList);
		}
		public void setUpBattle(List<EnemyBattleEntity> _enemies){
			//character list for testing
			List<PlayerBattleEntity> players = new List<PlayerBattleEntity>();
			/*public PlayerBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName)*/
			players.Add(new PlayerBattleEntity(5, 3, 10, 10, 10, 10, 10, "Howard", "Sprites/RED"));
			players.Add(new PlayerBattleEntity(5, 3, 10, 10, 10, 10, 10, "Steve", "Sprites/RED"));


			playerCharacters = players; //GameData.current.players;


			this.enemies = new List<EnemyBattleEntity>(_enemies);
			Debug.Log("BS enemy entities: " + enemies.Count);
			initBattle();
			//doBattle();
		}
		
		private void initBattle()
		{
			playerObjects = GameObject.FindGameObjectsWithTag("BattlePlayer");
			for (int i = 0; i < playerObjects.Length; i++)
			{
			  if (i<playerCharacters.Count){
			  	Debug.Log(playerObjects[i].name);
			  	playerObjects[i].GetComponent<SpriteRenderer>().sprite = playerObjects[i].GetComponent<BattleEntity>().getSprite(); 

			}
			}
			
			enemyObjects = GameObject.FindGameObjectsWithTag("BattleEnemy");
			for (int i = 0; i < enemyObjects.Length; i++)
			{
				if (i<enemies.Count){
					Debug.Log(enemyObjects[i].name);
					enemyObjects[i].GetComponent<SpriteRenderer>().sprite = enemyObjects[i].GetComponent<BattleEntity>().getSprite();
				}
				else{
					enemyObjects[i].SetActive(false);
				}
			}
		
		}
		
		
		
		private void doBattle()
		{
			while (!battleOver)
			{
				doBattleRound();
			}
			
			//System.out.println("The battle is over!");
			
		}
		
		private void checkForDeaths()
		{
			for (int i = 0; i < playerCharacters.Count; i++)
			{
				if (playerCharacters[i].getHp() <= 0)
				{
					//System.out.printf("%s dies.\n", playerCharacters.get(i).getName());
					playerCharacters.RemoveAt(i);
				}
			}
			
			for (int i = 0; i < enemies.Count; i++)
			{
				if (enemies[i].getHp() <= 0)
				{
					//System.out.printf("%s dies.\n", enemies.get(i).getName());
					enemies.RemoveAt(i);
				}
			}
			
			if (enemies.Count == 0 || playerCharacters.Count == 0)
			{
				battleOver = true;
			}
		}

		public void setAction(BattleAction theAction){
			theAction.doAction();
			checkForDeaths();
		}
		
		private void doBattleRound()
		{
			for (int i = 0; i < playerCharacters.Count; i++)
			{
				if (playerCharacters[i].isMyTurn())
				{
					//if it's PC1's turn ...
					if (i == 0){
						currentPlayerActions = player1Actions;
						currentPlayerActions.SetActive(true);
					}
					//if it's PC2's turn ... 
					else if(i == 1){
						currentPlayerActions = player2Actions;
						currentPlayerActions.SetActive(true);
					}
					Debug.Log (i);

					if (currentPlayerActions.GetComponent<RadioButtons>().currentValue.Equals("AttackButton")){
						foreach (GameObject anEnemy in enemyObjects){
							anEnemy.SendMessage("hilite");
						}
						foreach (GameObject aPlayer in playerObjects){
							aPlayer.SendMessage("hilite");
						}
					}
					else if(currentPlayerActions.GetComponent<RadioButtons>().currentValue.Equals("SkillButton")){
						foreach (GameObject anEnemy in enemyObjects){
							anEnemy.SendMessage("nohilite");
						}
						foreach (GameObject aPlayer in playerObjects){
							aPlayer.SendMessage("hilite");
						}
					}
					else{
						foreach(GameObject anEnemy in enemyObjects){
							anEnemy.SendMessage ("nohilite");
						}
						foreach (GameObject aPlayer in playerObjects){
							aPlayer.SendMessage("nohilite");
						}
					}

					//Debug.Log (i);
					//getUserAssignedAction(playerCharacters[i]);
					//action.doAction();
					//checkForDeaths();
					
				}
			}
			
			foreach (EnemyBattleEntity enemy in enemies)
			{
				if (enemy.isMyTurn())
				{
					/*BattleAction action = enemy.getEnemyAction(playerCharacters, enemies);
					action.doAction();
					checkForDeaths();*/
				}
			}
			
		}
		private BattleAction getUserAssignedAction(PlayerBattleEntity player)
		{
		//while(true){ int f = 1;}
			
			/*System.out.printf("It is %s's turn.\n", player.getName());
			System.out.printf("1. Attack\n");
			System.out.printf("2. Defend\n");
			System.out.printf("3. Use skill/magic\n");
			System.out.printf("4. Use item\n");
			
			int userInput = getUserInput();
			
			if (userInput == 1)
			{
				System.out.println("You chose to attack.");
				displayList(enemies);
				
				//This needs error handling added
				userInput = getUserInput();
				
				return new AttackBattleAction(player.getSpd(), player, enemies.get(userInput-1));
			}
			else if (userInput == 2)
			{
				return new DefendBattleAction(player.getSpd(), player);
			}
			
			*/
			
			// Highlight the player whose turn it is
			// Create a button for each of the possible actions 
			// A method that enables a GUI of buttons and returns which button was pressed, then gets disabled
			// If necessary, select a target for the action
			// A method that highlights all possible actions 
			// THEN create the attack battle action, or the defend battle action and return it as the result of this method
			
			
			return null;
			
			
		}
		
}
	
