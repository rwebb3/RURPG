using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

	public static GameData current;
	public Level currentLevel;

	public string name;
	public List<Level> levels;
	

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

	}
	
	public void setCurrentLevel(string newCurrentLevel){
		foreach (Level levelToCheck in levels){
			if (levelToCheck.name.Equals(newCurrentLevel)){
				currentLevel = levelToCheck;
			}
		}
	}	
		

}
