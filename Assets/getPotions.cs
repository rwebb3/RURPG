using UnityEngine;
using System.Collections;

public class getPotions : MonoBehaviour {

	public void UseButton(){
		GameData.current.healthPots += 5;
	}
}
