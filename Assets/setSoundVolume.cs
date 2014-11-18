using UnityEngine;
using System.Collections;

public class setSoundVolume : MonoBehaviour {

	void OnClick() {
		if (GlobalVars.soundVolume == 1.0f){
			GlobalVars.soundVolume = 0.0f;}
		else{
			GlobalVars.soundVolume = 1.0f;}
	}
}
