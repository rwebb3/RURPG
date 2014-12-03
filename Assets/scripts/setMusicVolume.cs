using UnityEngine;
using System.Collections;

public class setMusicVolume : MonoBehaviour {
	public UILabel theLabel;
	
	void OnClick(){
		if (GlobalVars.musicVolume == 1.0f){
		
			GlobalVars.musicVolume = 0.0f;
			theLabel.text = "Enable Music";
			
		}
		else{
			GlobalVars.musicVolume = 1.0f;
			theLabel.text = "Disable Music";
			}
	}
}
