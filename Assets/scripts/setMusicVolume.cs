using UnityEngine;
using System.Collections;

public class setMusicVolume : MonoBehaviour {

	void OnClick(){
		if (GlobalVars.musicVolume == 1.0f){
			GlobalVars.musicVolume = 0.0f;}
		else{
			GlobalVars.musicVolume = 1.0f;}
	}
}
