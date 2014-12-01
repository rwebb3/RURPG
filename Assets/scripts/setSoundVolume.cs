using UnityEngine;
using System.Collections;

public class setSoundVolume : MonoBehaviour {
<<<<<<< HEAD

=======
>>>>>>> menu
	public UILabel theLabel;
	void OnClick() {
		if (GlobalVars.soundVolume == 1.0f){
			GlobalVars.soundVolume = 0.0f;
<<<<<<< HEAD
			theLabel.text = "Enable Sound";
			}
		else{
			GlobalVars.soundVolume = 1.0f;
			theLabel.text = "Disable Sound";}
=======
			theLabel.text = "Enable Sound";}
		else{
			GlobalVars.soundVolume = 1.0f;
			theLabel.text = "Disable sound";}
>>>>>>> menu
	}
}
