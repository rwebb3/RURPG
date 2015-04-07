﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

	public static GameData current;
	public Level currentLevel;

	public string name;
	public List<Level> levels;
	
	public List<EntityStats> players;
	
	Level muse;
	Level davis;
	public Level tutorial;

	public GameData(){
		name = "";
		muse = new Level();
		davis = new Level();
		tutorial = new Level();

		muse.name = "Muse";
		davis.name = "Davis";
		tutorial.name = "TutorialLevel";

		levels = new List<Level>();
		levels.Add(muse);
		levels.Add(davis);
		levels.Add (tutorial);
		
		players = new List<EntityStats>();
		/*public PlayerBattleEntity(int hp, int sp, int atk, int def, int spd, int maxHP, int maxSP, string entityName)*/
		players.Add(new EntityStats(5, 3, 10, 10, 10, 10, 10, "Howard", "Sprites/RED"));
		players.Add(new EntityStats(5, 3, 10, 10, 10, 10, 10, "Steve", "Sprites/RED"));


	}
	
	public void setCurrentLevel(string newCurrentLevel){
		foreach (Level levelToCheck in levels){
			if (levelToCheck.name.Equals(newCurrentLevel)){
				currentLevel = levelToCheck;
			}
		}
	}	
		

}
