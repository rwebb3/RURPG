using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

	public static GameData current;
	public string name;
	public List<Level> levels;

	Level muse;
	Level davis;

	public GameData(){
		name = "";
		muse = new Level();
		davis = new Level();

		muse.name = "Muse";
		davis.name = "Davis";

		levels = new List<Level>();
		levels.Add(muse);
		levels.Add(davis);
	}

}
