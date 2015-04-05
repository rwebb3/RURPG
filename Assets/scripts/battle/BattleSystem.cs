using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour {
		public GameObject alertText;
		[HideInInspector]
		public List<EnemyBattleEntity> enemies;
		private List<PlayerBattleEntity> playerCharacters;
		private bool battleOver = false;

		void Start(){
			alertText.SetActive(false);
			alertText.SetActive(true);
			alertText.GetComponent<Text>().text = "test";
		}
		public void setUpBattle(List<EnemyBattleEntity> _enemies){
			playerCharacters = GameData.current.players;
			this.enemies = new List<EnemyBattleEntity>(_enemies);
			Debug.Log("BS enemy entities: " + enemies.Count);
			initBattle();
		}
		
		private void initBattle()
		{
			GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("BattlePlayer");
			for (int i = 0; i < playerObjects.Length; i++)
			{
			  if (i<playerCharacters.Count){
			  	Debug.Log(playerObjects[i].name);
			  	playerObjects[i].GetComponent<SpriteRenderer>().sprite = playerCharacters[i].getSprite(); 
			}
			}
			
			GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("BattleEnemy");
			for (int i = 0; i < enemyObjects.Length; i++)
			{
				if (i<enemies.Count){
					Debug.Log(enemyObjects[i].name);
					enemyObjects[i].GetComponent<SpriteRenderer>().sprite = enemies[i].getSprite();
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
		
		private void doBattleRound()
		{
			
			
			foreach (PlayerBattleEntity playerCharacter in playerCharacters)
			{
				if (playerCharacter.isMyTurn())
				{
					BattleAction action = getUserAssignedAction(playerCharacter);
					action.doAction();
					checkForDeaths();
				}
			}
			
			foreach (EnemyBattleEntity enemy in enemies)
			{
				if (enemy.isMyTurn())
				{
					BattleAction action = enemy.getEnemyAction(playerCharacters, enemies);
					action.doAction();
					checkForDeaths();
				}
			}
			
		}
		private BattleAction getUserAssignedAction(PlayerBattleEntity player)
		{
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
	
