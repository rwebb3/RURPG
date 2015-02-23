using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveLoad{

	public static int FilNum;
	public static GameData[] savedGames = new GameData[3];

	public static void Save(){
		savedGames[FilNum] = GameData.current;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.rugs");
		bf.Serialize(file, SaveLoad.savedGames);
		file.Close();
	}

	public static void Load(){
		if(File.Exists(Application.persistentDataPath + "/savedGames.rugs")){
			Debug.Log("file exists");
		   BinaryFormatter bf = new BinaryFormatter();
		   FileStream file = File.Open(Application.persistentDataPath + "/savedGames.rugs", FileMode.Open);
		   SaveLoad.savedGames = (GameData[])bf.Deserialize(file);
		   file.Close();
		}
	}
}
